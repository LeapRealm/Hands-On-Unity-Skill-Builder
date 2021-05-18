using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {

    }
}