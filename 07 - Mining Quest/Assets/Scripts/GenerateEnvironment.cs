using UnityEngine;

public class GenerateEnvironment : MonoBehaviour
{
    [SerializeField] private GameObject groundTilePrefab;
    [SerializeField] private GameObject rockTilePrefab;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private GameObject exitPrefab;
    [SerializeField] private GameObject enemyPrefab;
    
    [SerializeField] private Sprite[] groundSprites;
    [SerializeField] private Sprite[] rockSprites;
    [SerializeField] private Sprite[] foodSprites;
    
    [SerializeField] private int amountOfEnemies;
    [SerializeField] private int amountOfRocks;
    [SerializeField] private int amountOfFoods;

    private int exitLocation;
    private bool[,] hasSprite = new bool[20, 20];
    private Vector2 playerSpawnPoint = new Vector2(10, 10);

    private void Start()
    {
        hasSprite[10, 10] = true;

        GenerateFloor();
        SpawnExit();
        SpawnEnemies();
        GenerateRock();
        GenerateFood();
    }

    private void GenerateFloor()
    {
        for (int x = 0; x < 20; x++)
        for (int y = 0; y < 20; y++)
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
            new Vector2(0, 0), new Vector2(0, 19), new Vector2(19, 0), new Vector2(19, 19)
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
                xCoord = Random.Range(0, 19);
                yCoord = Random.Range(0, 19);
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
                xCoord = Random.Range(0, 20);
                yCoord = Random.Range(0, 20);
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
                xCoord = Random.Range(0, 20);
                yCoord = Random.Range(0, 20);
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