using UnityEngine;

public class Scorer : MonoBehaviour
{
    [SerializeField] private ParticleSystem celebration;
    private bool hasChildren = true;

    private void Update()
    {
        if (transform.childCount == 0)
        {
            celebration.Play();
        }
    }
}