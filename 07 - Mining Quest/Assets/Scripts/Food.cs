using UnityEngine;

public class Food : MonoBehaviour
{
    private GameHandler gameHandler;

    private void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameHandler.updateFood();
        }
    }
}