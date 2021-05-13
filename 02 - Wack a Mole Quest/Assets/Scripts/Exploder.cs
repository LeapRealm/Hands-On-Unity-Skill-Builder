using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private ParticleSystem catchParticleSource;

    private void OnTriggerEnter(Collider other)
    {
        print("Aww, you got me");
        ParticleSystem catchParticle = Instantiate(catchParticleSource, GetComponentsInChildren<Transform>()[1].position, Quaternion.identity);
        catchParticle.Play();

        Mover mover = other.GetComponent<Mover>();
        if (mover != null)
            mover.StartTimeScaleCoroutine();
        
        Destroy(gameObject);
    }
}