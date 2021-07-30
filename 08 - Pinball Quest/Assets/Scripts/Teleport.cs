using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform outTransform;
    [SerializeField] private float force;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        Rigidbody2D playerRigidbody2D = other.GetComponent<Rigidbody2D>();
        playerRigidbody2D.velocity = Vector2.zero;
        playerRigidbody2D.transform.position = outTransform.position;
        playerRigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
}