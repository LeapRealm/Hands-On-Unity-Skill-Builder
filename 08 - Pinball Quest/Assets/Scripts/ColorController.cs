using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorController : MonoBehaviour
{
    [SerializeField] private Color color;
    private SpriteRenderer spriteRenderer;
    private Coroutine coroutine;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(ChangeColor());
    }

    public IEnumerator ChangeColor()
    {
        spriteRenderer.color = color;
        yield return new WaitForSeconds(1.0f);
        spriteRenderer.color = Color.white;
        coroutine = null;
    }
}