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
        GenerateRock();
        GenerateFood();
        
        SpawnExit();
        SpawnEnemies();
    }

    private void GenerateFloor()
    {
        for (int x = 0; x < 20; x++)
            for (int y = 0; y < 20; y++)
                InstantiateFloorTile(x, y);
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
            int randomFoodSpriteIndex = Random.Range(0, foodSprites.Length);
            food.GetComponent<SpriteRenderer>().sprite = foodSprites[randomFoodSpriteIndex];
        }
    }

    private void InstantiateFloorTile(int x, int y)
    {
        GameObject newFloorTile = Instantiate(groundTilePrefab, new Vector2(x, y), Quaternion.identity);
        newFloorTile.GetComponent<SpriteRenderer>().sprite = groundSprites[Random.Range(0, groundSprites.Length)];
    }

    private void SpawnExit()
    {
        // Challenge 2
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < amountOfEnemies; i++)
        {
            Vector2 spawnLocation = new Vector2(Random.Range(0, 19), Random.Range(0, 19));
            GameObject newEnemy = Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
        }
    }
}