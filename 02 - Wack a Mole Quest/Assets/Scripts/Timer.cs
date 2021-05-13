using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;
    private float elapsedTime;

    private void Start()
    {
        timerText = GetComponent<Text>();
    }

    private void Update()
    {
        
    }
}