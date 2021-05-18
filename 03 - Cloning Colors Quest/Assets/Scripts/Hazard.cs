using UnityEngine;

public class Hazard : MonoBehaviour
{
    private GameHandler gameHandler;

    private void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            if (collision.gameObject.GetComponent<BlockMovement>().isActiveBool)
            {
                Destroy(collision.gameObject);
                gameHandler.AllPlayerBlocksArrayUpdate();
                gameHandler.DestroyedBlockUpdate();
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}