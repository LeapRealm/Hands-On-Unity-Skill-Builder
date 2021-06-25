using UnityEngine;

public class GenerateEnvironment : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject groundTilePrefab;
    [SerializeField] private GameObject rockTilePrefab;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private GameObject exitPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private Sprite[] groundSprites;
    [SerializeField] private Sprite[] rockSprites;
    [SerializeField] private Sprite[] foodSprites;

    private int amountOfEnemies;
    private int amountOfRocks;
    private int amountOfFoods;

    private int exitLocation;
    private int mapSideSize;
    private bool[,] hasSprite;
    private Vector2 playerSpawnPoint;

    private void Start()
    {
        mapSideSize = Random.Range(15, 41);
        hasSprite = new bool[mapSideSize, mapSideSize];

        playerSpawnPoint = new Vector2((int) (mapSideSize / 2.0f), (int) (mapSideSize / 2.0f));
        player.transform.position = playerSpawnPoint;
        hasSprite[(int) playerSpawnPoint.x, (int) playerSpawnPoint.y] = true;

        amountOfEnemies = (int) (mapSideSize * 0.2f);
        amountOfRocks = (int) (mapSideSize * 15.0f);
        amountOfFoods = (int) (mapSideSize * 1.2f);

        GenerateFloor();
        SpawnExit();
        SpawnEnemies();
        GenerateRock();
        GenerateFood();
    }

    private void GenerateFloor()
    {
        for (int x = 0; x < mapSideSize; x++)
        for (int y = 0; y < mapSideSize; y++)
            InstantiateFloorTile(x, y);
    }

    private void InstantiateFloorTile(int x, int y)
    {
        GameObject newFloorTile = Instantiate(groundTilePrefab, new Vector2(x, y), Quaternion.identity);
        newFloorTile.transform.parent = gameObject.transform;
        newFloorTile.GetComponent<SpriteRenderer>().sprite = groundSprites[Random.Range(0, groundSprites.Length)];
    }

    private void SpawnExit()
    {
        Vector2[] exitPositions = new[]
        {
            new Vector2(0, 0),
            new Vector2(0, mapSideSize - 1),
            new Vector2(mapSideSize - 1, 0),
            new Vector2(mapSideSize - 1, mapSideSize - 1)
        };

        int exitPositionIndex = Random.Range(0, exitPositions.Length);
        hasSprite[(int) exitPositions[exitPositionIndex].x, (int) exitPositions[exitPositionIndex].y] = true;
        GameObject exit = Instantiate(exitPrefab, exitPositions[exitPositionIndex], Quaternion.identity);
        exit.transform.parent = gameObject.transform;
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < amountOfEnemies; i++)
        {
            int xCoord, yCoord;
            do
            {
                xCoord = Random.Range(0, mapSideSize);
                yCoord = Random.Range(0, mapSideSize);
            } while (hasSprite[xCoord, yCoord] || isPlayerSpawnArea(xCoord, yCoord));

            Vector2 spawnPosition = new Vector2(xCoord, yCoord);
            hasSprite[xCoord, yCoord] = true;

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            newEnemy.transform.parent = gameObject.transform;
        }
    }

    private bool isPlayerSpawnArea(int xCoord, int yCoord)
    {
        if (xCoord >= playerSpawnPoint.x - 1 && xCoord <= playerSpawnPoint.x + 1 &&
            yCoord >= playerSpawnPoint.y - 1 && yCoord <= playerSpawnPoint.y + 1)
            return true;
        else
            return false;
    }

    private void GenerateRock()
    {
        for (int i = 0; i < amountOfRocks; i++)
        {
            int xCoord, yCoord;
            do
            {
                xCoord = Random.Range(0, mapSideSize);
                yCoord = Random.Range(0, mapSideSize);
            } while (hasSprite[xCoord, yCoord]);

            Vector2 spawnPosition = new Vector2(xCoord, yCoord);
            hasSprite[xCoord, yCoord] = true;

            GameObject rock = Instantiate(rockTilePrefab, spawnPosition, Quaternion.identity);
            rock.transform.parent = gameObject.transform;

            int randomRockSpriteIndex = Random.Range(0, rockSprites.Length);
            rock.GetComponent<SpriteRenderer>().sprite = rockSprites[randomRockSpriteIndex];
        }
    }

    private void GenerateFood()
    {
        for (int i = 0; i < amountOfFoods; i++)
        {
            int xCoord, yCoord;
            do
            {
                xCoord = Random.Range(0, mapSideSize);
                yCoord = Random.Range(0, mapSideSize);
            } while (hasSprite[xCoord, yCoord]);

            Vector2 spawnPosition = new Vector2(xCoord, yCoord);
            hasSprite[xCoord, yCoord] = true;

            GameObject food = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
            food.transform.parent = gameObject.transform;

            int randomFoodSpriteIndex = Random.Range(0, foodSprites.Length);
            food.GetComponent<SpriteRenderer>().sprite = foodSprites[randomFoodSpriteIndex];
        }
    }
}