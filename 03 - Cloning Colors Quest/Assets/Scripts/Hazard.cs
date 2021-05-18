using UnityEngine;

public class Hazard : MonoBehaviour
{
    private GameHandler gameHandler;
    private ColorChanger colorChanger;

    private void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();
        colorChanger = GetComponent<ColorChanger>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            ColorChanger otherColorChanger = other.GetComponent<ColorChanger>();
            if (otherColorChanger == null)
                return;
            
            if (otherColorChanger.blockColor == colorChanger.blockColor)
                return;
            
            if (other.gameObject.GetComponent<BlockMovement>().isActiveBool)
            {
                Destroy(other.gameObject);
                gameHandler.AllPlayerBlocksArrayUpdate();
                gameHandler.DestroyedBlockUpdate();
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}