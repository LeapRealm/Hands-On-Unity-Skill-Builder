using UnityEngine;

// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform teleportTarget;
    [SerializeField] private GameObject player;
    [SerializeField] private Light areaLight;
    [SerializeField] private Light mainWorldLight;
    [SerializeField] private GameObject nextPlatform;
    [SerializeField] private Material teleporterNormalMaterial;
    [SerializeField] private Material teleporterEmissionMaterial;

    private void Start() 
    {
        // CHALLENGE TIP: Make sure all relevant lights are turned off until you need them on
        // because, you know, that would look cool.
    }

    private void OnTriggerEnter(Collider other) 
    {
        TeleportPlayer();
        DeactivateObject();
        IlluminateArea();
        // Challenge 5: StartCoroutine ("BlinkWorldLight");
        // Challenge 6: TeleportPlayerRandom();
    }

    private void TeleportPlayer()
    {
        player.transform.position = teleportTarget.position;
    }

    private void DeactivateObject()
    {
        gameObject.SetActive(false);
    }

    private void IlluminateArea()
    {
        GetComponent<MeshRenderer>().material = teleporterNormalMaterial;
        nextPlatform.GetComponent<MeshRenderer>().material = teleporterEmissionMaterial;
    }

    // private IEnumerator BlinkWorldLight()
    // {
            // code goes here
    // }

    private void TeleportPlayerRandom()
    {
        // code goes here... or you could modify one of your other methods to do the job.
    }
}