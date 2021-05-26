using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<PlatformManager>();

            return _instance;
        }
    }

    private static PlatformManager _instance;

    [SerializeField] private List<PlatformController> platforms;
    [SerializeField] private List<GameObject> platformPrefabs;
    private int lastPlatformIndex;
    
    private void Awake()
    {
        if (instance != this)
            Destroy(gameObject);
        
        lastPlatformIndex = FindObjectsOfType<PlatformController>().Length - 1;
    }

    public void SpawnPlatform()
    {
        int prefabIndex = Random.Range(0, platformPrefabs.Count);
        float positionYDelta = Random.Range(-3, 4);
        Vector3 spawnPosition = platforms[lastPlatformIndex].originalSpawnTransform.position + new Vector3(0f, positionYDelta, 0f);
        
        GameObject newPlatformGameObject = Instantiate(platformPrefabs[prefabIndex], spawnPosition, Quaternion.identity);
        newPlatformGameObject.transform.parent = transform;
        
        platforms.Add(newPlatformGameObject.GetComponent<PlatformController>());
        lastPlatformIndex++;
    }
}