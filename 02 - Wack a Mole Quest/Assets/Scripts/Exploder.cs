using UnityEngine;

public class Exploder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Aww, you got me");
        Destroy(gameObject);
    }
}