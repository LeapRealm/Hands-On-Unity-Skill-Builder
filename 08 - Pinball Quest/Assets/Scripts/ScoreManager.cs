using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private long score = 0;
    public static ScoreManager instance;

    private int multiplier = 1;
    public int Multiplier
    {
        get => multiplier;
        set => multiplier = value;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateScore(int addScore)
    {
        score += addScore * Multiplier;
    }

    private void Update()
    {
        scoreText.text = "Current Score\n" + score.ToString() + "\nX" + Multiplier;
    }
}