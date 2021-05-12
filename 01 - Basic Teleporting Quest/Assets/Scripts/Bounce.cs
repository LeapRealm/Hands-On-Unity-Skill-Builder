using UnityEngine;

// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

public class Bounce : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1000f;

    private void OnTriggerEnter(Collider other)
    {
        JumpyJumpy(other);
    }

    private void JumpyJumpy(Collider other)
    {
        Rigidbody rigidbody3D = other.GetComponent<Rigidbody>();
        if (rigidbody3D == null)
            return;
        
        rigidbody3D.AddForce(Vector3.up * jumpForce);
    }
}