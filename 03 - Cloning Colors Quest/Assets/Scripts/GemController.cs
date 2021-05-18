using UnityEngine;

public class GemController : MonoBehaviour
{
    private SpriteRenderer gemSpriteRenderer;

    private void Start()
    {
        gemSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SpriteRenderer otherSpriteRenderer = other.GetComponent<SpriteRenderer>();
        
        if (otherSpriteRenderer == null)
            return;

        otherSpriteRenderer.color = gemSpriteRenderer.color;
    }
}