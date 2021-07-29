using UnityEngine;

public class FlatBumperController : MonoBehaviour
{
    [SerializeField] private float force;
    private Rigidbody2D playerRigidbody2D;
    private Transform dirTransform;

    private void Start()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        playerRigidbody2D = playerGameObject.GetComponent<Rigidbody2D>();

        dirTransform = GetComponentsInChildren<Transform>()[1];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        
        playerRigidbody2D.AddForce(dirTransform.transform.forward * force, ForceMode2D.Impulse);
    }
}