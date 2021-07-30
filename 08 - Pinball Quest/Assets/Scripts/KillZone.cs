using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KillZone : MonoBehaviour
{
    [SerializeField] private int lifeLeft;
    [SerializeField] private Text lifeLeftText;
    [SerializeField] private PolygonCollider2D ballStopperPolygonCollider2D;
    private GameObject player;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (lifeLeft >= 1)
        {
            lifeLeft--;
            lifeLeftText.text = "Life Left\n" + lifeLeft.ToString();
            
            player.transform.position = new Vector3(9.09f, -10.75f, 0);
            ballStopperPolygonCollider2D.enabled = false;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}