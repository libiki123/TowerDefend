using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float baseSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float baseHealth = 100f;
    [HideInInspector]
    public float health;

    public int worth = 50;

    public GameObject enemyDeathEffect;

    [Header("Unity Sruffs")]
    public Image healthBar;

    private bool isDead = false;

    private void Start()
    {
        speed = baseSpeed;
        health = baseHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / baseHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        PlayerStats.Money += worth;

        SoundManager.playSound("enemyDeath");

        GameObject deathEffect = (GameObject)Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffect, 4f);

        WaveSpawner.EnemyAlive--;

        Destroy(gameObject);
    }

    public void Slow(float slowPercent)
    {
        speed = speed * (1f - slowPercent);
    }

}
