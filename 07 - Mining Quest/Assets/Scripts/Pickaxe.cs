using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    private PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
            player.SetTargetBlock(other.gameObject);
    }
}