using System.Collections;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }

    private void Update()
    {
        transform.Translate(transform.right * 50f * Time.deltaTime);
    }
    
    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("DestructableCube"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}