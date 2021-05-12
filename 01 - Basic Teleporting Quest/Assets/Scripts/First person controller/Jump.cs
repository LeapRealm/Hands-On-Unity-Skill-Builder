using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private GroundCheck groundCheck;
    private Rigidbody rigidbody3D;
    public float jumpStrength = 2;
    public event System.Action Jumped;
    
    private void Reset()
    {
        groundCheck = GetComponentInChildren<GroundCheck>();
        if (!groundCheck)
            groundCheck = GroundCheck.Create(transform);
    }

    private void Awake()
    {
        rigidbody3D = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        if (Input.GetButtonDown("Jump") && groundCheck.isGrounded)
        {
            rigidbody3D.AddForce(Vector3.up * 100 * jumpStrength);
            Jumped?.Invoke();
        }
    }
}