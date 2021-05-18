using UnityEngine;

public class GemController : MonoBehaviour
{
    private ColorChanger gemColorChanger;

    private void Start()
    {
        gemColorChanger = GetComponent<ColorChanger>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ColorChanger otherColorChanger = other.GetComponent<ColorChanger>();
        if (otherColorChanger == null)
            return;

        otherColorChanger.blockColor = gemColorChanger.blockColor;
    }
}