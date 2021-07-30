using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    [SerializeField] private float force;
    private bool canLaunch = false;
    private Rigidbody2D playerRigidbody2D;

    private void OnTriggerEnter2D(Collider2D other)
    {
        canLaunch = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canLaunch = false;
    }

    private void Start()
    {
        playerRigidbody2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canLaunch && Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            canLaunch = false;
        }
    }
}