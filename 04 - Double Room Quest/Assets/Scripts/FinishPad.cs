using UnityEngine;

public class FinishPad : MonoBehaviour
{
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
            //Challenge 4:  
        }
    }
}