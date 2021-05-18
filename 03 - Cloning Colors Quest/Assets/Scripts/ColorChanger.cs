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

    [SerializeField] private BlockColor _blockColor;
    public BlockColor blockColor
    {
        get => _blockColor;
        set
        {
            _blockColor = value;
            ChangeBlockColor();
        }
    }

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ChangeBlockColor();
    }

    private void ChangeBlockColor()
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