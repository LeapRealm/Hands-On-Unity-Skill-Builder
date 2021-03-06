using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject youWinText;
    [SerializeField] private List<PlayerMovement> allPlayerCubes = new List<PlayerMovement>();

    private void Start()
    {
        allPlayerCubes.AddRange(FindObjectsOfType<PlayerMovement>());
    }

    public void RemovePlayerCubeFromList(PlayerMovement thisCube)
    {
        allPlayerCubes.Remove(thisCube);
        CheckIfLevelComplete();
    }

    private void CheckIfLevelComplete()
    {
        if (allPlayerCubes.Count == 0)
            youWinText.SetActive(true);
    }
}