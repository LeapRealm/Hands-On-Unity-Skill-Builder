using UnityEngine;

public class SpawnNewBlock : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private Transform spawnPosition;

    public void SpawnBlock()
    {
        Instantiate(blockPrefab, spawnPosition.position, Quaternion.identity);
    }
}