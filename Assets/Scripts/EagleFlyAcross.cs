using UnityEngine;

public class EagleFlyAcross : MonoBehaviour
{
    public GameObject bird;
    public float sidewayForce = 500f;

    private bool isVisible = false;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        bird.GetComponent<Rigidbody>().AddForce(sidewayForce * Time.deltaTime, 0, 0);

        if (transform.position.x >= -10f * Time.deltaTime && !isVisible)
        {
            isVisible = true;
            if (isVisible)
            {
                SoundManager.playSound("bird");
                return;
            }
        }


        if (transform.position.x >= startPosition.x + 400f)
        {
            
            Invoke("ResetPosition", 3);
        }
    }

    void ResetPosition()
    {
        transform.position = startPosition;
        isVisible = false;
    }

}
