using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy enemy;

    [Header("General")]

    public float range = 15f;

    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Lazer")]
    public bool useLazer = false;
    public LineRenderer lineRenderer;
    public ParticleSystem lazerImpactEffect;
    public Light lazerImpactLight;
    public int damageOverTime = 30;
    public float slowPercent = .5f;

    [Header("Unity Settup Fields")]
    public Transform partToRotate;
    
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;

    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, .5f);
    }

    // Update is called once per frame
    void Update()
    {
       if(target == null)
        {
            if (useLazer)
            {
                lineRenderer.enabled = false;
                lazerImpactEffect.Stop();
                lazerImpactLight.enabled = false;
            }

            return;
        }
            

        LockOnTarget();

        if (useLazer) {
            Lazer();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
 
    }

    void Lazer()
    {
        enemy.TakeDamage(damageOverTime * Time.deltaTime);
        enemy.Slow(slowPercent);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            lazerImpactEffect.Play();
            lazerImpactLight.enabled = true;

        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        lazerImpactEffect.transform.position = target.position + dir.normalized;
        lazerImpactEffect.transform.rotation = Quaternion.LookRotation(dir);

    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            enemy = nearestEnemy.GetComponent<Enemy>();
        } else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
