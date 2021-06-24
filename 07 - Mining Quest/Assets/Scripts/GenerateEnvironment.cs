using UnityEngine;

public class GenerateEnvironment : MonoBehaviour
{
    [SerializeField] private GameObject groundTilePrefab;
    [SerializeField] private Sprite[] groundSprites;
    [SerializeField] private GameObject rockTilePrefab;
    [SerializeField] private Sprite[] rockSprites;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private Sprite[] foodSprites;
    [SerializeField] private GameObject exitPrefab;
    [SerializeField] private int amountOfEnemies;
    [SerializeField] private GameObject enemyPrefab;

    private int exitLocation;
    private bool[,] hasSprite = new bool[20, 20];

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
        hasSprite[(int)exitPositions[exitPositionIndex].x, (int)exitPositions[exitPositionIndex].y] = true;
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
            } while (hasSprite[xCoord, yCoord]);

            Vector2 spawnPosition = new Vector2(xCoord, yCoord);
            hasSprite[xCoord, yCoord] = true;
            
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            newEnemy.transform.parent = gameObject.transform;
        }
    }

    private void GenerateRock()
    {
        for (int i = 0; i < 280; i++)
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
        for (int i = 0; i < 20; i++)
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