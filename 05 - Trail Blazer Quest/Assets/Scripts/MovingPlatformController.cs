using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    private float elapsedTime = 0f;
    private float originalPositionY;

    private void Start()
    {
        originalPositionY = transform.position.y;
    }

    private void Update()
    {
        float newPositionY = originalPositionY + Mathf.PingPong(elapsedTime, 2);
        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
        elapsedTime += Time.deltaTime;
    }
}