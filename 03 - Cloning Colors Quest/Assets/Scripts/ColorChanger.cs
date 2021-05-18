using UnityEngine;

public enum BlockColor
{
    Red,
    Yellow,
    Blue
}

public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    public BlockColor blockColor;

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        switch (blockColor)
        {
            case BlockColor.Red:
                mySpriteRenderer.color = Color.red;
                break;
            case BlockColor.Yellow:
                mySpriteRenderer.color = Color.yellow;
                break;
            case BlockColor.Blue:
                mySpriteRenderer.color = Color.blue;
                break;
        }
    }
}