using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private GameHandler gameHandler;

    private void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();
    }
    
    public void RetryButton()
    {
        gameHandler.resetFoodCount();
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}