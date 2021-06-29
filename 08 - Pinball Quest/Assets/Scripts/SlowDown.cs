using UnityEngine;

public class SlowDown : MonoBehaviour
{
    [SerializeField] private bool beSlow;

    private void Update()
    {
        if (beSlow)
            Time.timeScale = 0.5f;
        else
            Time.timeScale = 1.0f;
    }
}