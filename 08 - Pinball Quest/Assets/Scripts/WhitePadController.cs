using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WhitePadController : MonoBehaviour
{
    [SerializeField] private Color selectedColor;
    private Color defaultColor;
    private Coroutine coroutine;
    private SpriteRenderer spriteRenderer;
    private bool isOn = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.transform.CompareTag("Player"))
            return;

        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(ChangeColor());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.transform.CompareTag("Player"))
            return;

        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        if (isOn)
            ScoreManager.instance.Multiplier++;
        
        spriteRenderer.color = selectedColor;
        isOn = true;
        
        yield return new WaitForSeconds(5.0f);
        
        spriteRenderer.color = defaultColor;
        isOn = false;
        ScoreManager.instance.Multiplier = 1;
        coroutine = null;
    }
}