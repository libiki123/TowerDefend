using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool outOfFrame = false;
    private Vector3 startCamPos;

    public float panSpeed = 30f;
    public float panBorderThicness = 10f;
    public float scrollSpeed = 5f;

    [Header("Clamp Position")]
    public float minY = 20f;
    public float maxY = 200f;
    public float minX = -20f;
    public float maxX = 80f;
    public float minZ = -80f;
    public float maxZ = 60f;

    private void Start()
    {
        startCamPos = transform.position;
    }

    void Update()
    {
        if (GameManager.gameEnded)
        {
            transform.position = startCamPos;
            this.enabled = false;
            return;
        }

        if (!outOfFrame)
        {
            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThicness)
            {
                // Translate use to move an object without physic system
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThicness)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThicness)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThicness)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Vector3 pos = transform.position;

            pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

            transform.position = pos;

        }
        
    }
}
