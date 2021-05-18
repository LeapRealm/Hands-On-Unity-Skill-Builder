using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagController : MonoBehaviour
{
    private ColorChanger myColorChanger;
    
    private void Start()
    {
        myColorChanger = GetComponent<ColorChanger>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        ColorChanger otherColorChanger = other.GetComponent<ColorChanger>();
        if (otherColorChanger == null)
            return;

        if (otherColorChanger.blockColor != myColorChanger.blockColor)
            return;

        if (FindObjectsOfType<CoinController>().Length != 0)
            return;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}