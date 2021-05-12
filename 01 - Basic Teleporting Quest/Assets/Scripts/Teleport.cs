using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform teleportTarget;
    [SerializeField] private GameObject player;
    [SerializeField] private Light mainWorldLight;
    [SerializeField] private GameObject nextPlatform;
    [SerializeField] private Material teleporterNormalMaterial;
    [SerializeField] private Material teleporterEmissionMaterial;
    [SerializeField] private Transform[] nextTransforms;

    private void OnTriggerEnter(Collider other) 
    {
        // TeleportPlayer();
        TeleportPlayerRandom();
        IlluminateArea();
        StartCoroutine(BlinkWorldLight());
    }

    private void TeleportPlayer()
    {
        player.transform.position = teleportTarget.position;
    }
    
    private void TeleportPlayerRandom()
    {
        player.transform.position = nextTransforms[Random.Range(0, nextTransforms.Length)].position;
    }
    
    private void IlluminateArea()
    {
        GetComponent<MeshRenderer>().material = teleporterNormalMaterial;
        nextPlatform.GetComponent<MeshRenderer>().material = teleporterEmissionMaterial;
    }
    
    private IEnumerator BlinkWorldLight()
    {
        mainWorldLight.enabled = true;
        yield return new WaitForSeconds(1.0f);
        mainWorldLight.enabled = false;
        
        DeactivateObject();
    }
    
    private void DeactivateObject()
    {
        gameObject.SetActive(false);
    }
}