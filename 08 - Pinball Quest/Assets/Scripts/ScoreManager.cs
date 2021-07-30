using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private long score = 0;
    public static ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = score.ToString();
    }
}