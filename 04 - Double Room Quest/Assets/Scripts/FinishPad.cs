using UnityEngine;

public class FinishPad : MonoBehaviour
{
    [SerializeField] private GameObject goalParticlePrefab;
    private GameHandler gameHandler;

    private void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            gameHandler.RemovePlayerCubeFromList(other.gameObject.GetComponent<PlayerMovement>());
            Destroy(other.gameObject);
            Instantiate(goalParticlePrefab, transform.position, Quaternion.identity);
        }
    }
}