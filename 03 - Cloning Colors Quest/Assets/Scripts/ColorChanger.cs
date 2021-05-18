using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private enum BlockColor
    {
        Red,
        Yellow,
        Blue
    }
    
    private SpriteRenderer mySpriteRenderer;
    [SerializeField] private BlockColor blockColor;

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