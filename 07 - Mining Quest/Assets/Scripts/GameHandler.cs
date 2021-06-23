using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text FoodAmountText;
    [SerializeField] private int foodCollected = 0;

    private void Awake()
    {
        int gameHandlerCount = FindObjectsOfType<GameHandler>().Length;
        if (gameHandlerCount > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        FoodAmountText = GameObject.Find("FoodAmountText").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        FoodAmountText = GameObject.Find("FoodAmountText").GetComponent<TMP_Text>();
        FoodAmountText.text = foodCollected.ToString();
    }

    public void updateFood()
    {
        foodCollected++;
    }

    public void resetFoodCount()
    {
        foodCollected = 0;
    }
}