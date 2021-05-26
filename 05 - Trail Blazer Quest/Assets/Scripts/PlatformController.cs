using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform originalSpawnTransform;
    private bool isExecuted = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (isExecuted)
            return;

        isExecuted = true;
        PlatformManager.instance.SpawnPlatform();
    }
}