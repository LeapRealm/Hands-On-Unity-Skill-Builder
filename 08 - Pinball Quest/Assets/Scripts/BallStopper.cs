using UnityEngine;

public class BallStopper : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D ballStopperPolygonCollider2D;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            ballStopperPolygonCollider2D.enabled = true;
    }
}