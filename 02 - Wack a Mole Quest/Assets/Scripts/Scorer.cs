using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scorer : MonoBehaviour
{
    [SerializeField] private ParticleSystem celebration;
    private bool isPlayed = false;

    private void Update()
    {
        if (!isPlayed && transform.childCount == 0)
        {
            isPlayed = true;
            celebration.Play();
            StartCoroutine(RestartScene());
        }
    }

    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}