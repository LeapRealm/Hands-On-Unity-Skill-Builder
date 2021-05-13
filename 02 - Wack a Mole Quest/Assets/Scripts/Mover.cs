using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Mover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    public Text gameSpeedText;
    
    private void Update()
    {
        MoveHero();
    }

    private void MoveHero()
    {
        float xValue = moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float yValue = moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(xValue, 0, yValue);
    }

    public void StartTimeScaleCoroutine()
    {
        StartCoroutine(SetTimeScale());
    }
    
    public IEnumerator SetTimeScale()
    {
        Time.timeScale = 0.5f;
        gameSpeedText.text = "Game Speed : Slow";
        
        yield return new WaitForSeconds(0.5f);
        
        Time.timeScale = 1.0f;
        gameSpeedText.text = "Game Speed : Normal";
    }
}