using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private int addScore;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        ScoreManager.instance.UpdateScore(addScore);
    }
}