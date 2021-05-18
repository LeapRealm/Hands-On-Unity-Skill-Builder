using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnNewBlock : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private Transform spawnPosition;
    private int blockColorEnumElementCount;

    private void Start()
    {
        string[] blockColorEnumElementNames = Enum.GetNames(typeof(BlockColor));
        blockColorEnumElementCount = blockColorEnumElementNames.Length;
    }

    public void SpawnBlock()
    {
        GameObject blockGameObject = Instantiate(blockPrefab, spawnPosition.position, Quaternion.identity);
        ColorChanger blockColorChanger = blockGameObject.GetComponent<ColorChanger>();
        
        BlockColor randomBlockColor = (BlockColor) Random.Range(0, blockColorEnumElementCount);
        blockColorChanger.blockColor = randomBlockColor;
    }
}