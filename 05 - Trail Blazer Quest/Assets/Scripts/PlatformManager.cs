using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

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
    
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI coinText;
    public PlayerMovement playerMovement;
    private float currentDistance = 0;
    private int currentCoinScore = 0;
    
    [SerializeField] private List<PlatformController> platforms;
    [SerializeField] private List<GameObject> platformPrefabs;
    private int lastPlatformIndex;
    
    private void Awake()
    {
        if (instance != this)
            Destroy(gameObject);
        
        lastPlatformIndex = FindObjectsOfType<PlatformController>().Length - 1;
    }

    private void Update()
    {
        currentDistance = Mathf.Abs(playerMovement.transform.position.x - 0.37f);
        distanceText.text = $"distance : {Mathf.Round(currentDistance)}m";
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

    public void AddCoinScore()
    {
        currentCoinScore++;
        coinText.text = $"coin : {currentCoinScore}";
    }
}