using UnityEngine;

public class BoostItemController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            PlatformManager.instance.playerMovement.baseSpeed += 0.2f;
            Destroy(gameObject);
        }
    }
}