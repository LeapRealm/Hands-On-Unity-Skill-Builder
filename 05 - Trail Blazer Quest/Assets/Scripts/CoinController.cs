using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0f,0f,360f) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            PlatformManager.instance.AddCoinScore();
            Destroy(gameObject);
        }
    }
}