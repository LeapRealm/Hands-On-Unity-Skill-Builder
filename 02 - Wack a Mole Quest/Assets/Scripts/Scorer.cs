using UnityEngine;

public class Scorer : MonoBehaviour
{
    [SerializeField] private ParticleSystem celebration;
    private bool isPlayed = false;

    private void Update()
    {
        if (!isPlayed && transform.childCount == 0)
        {
            celebration.Play();
            isPlayed = true;
        }
    }
}