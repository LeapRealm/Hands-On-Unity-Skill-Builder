using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D ballStopperPolygonCollider2D;
    private GameObject player;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = new Vector3(9.09f, -10.75f, 0);
            ballStopperPolygonCollider2D.enabled = false;
        }
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}