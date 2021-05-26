using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float gravity = -30f;
    [SerializeField] private float baseSpeed = 1f;
    [SerializeField] private float jumpHeight = 1f;
    [SerializeField] private float distanceCheck = 1f;
    [SerializeField] private float boostModifier = 1f;
    [SerializeField] private int numberOfJumps = 2;
    [SerializeField] private float horizontalSpeed;

    private CharacterController characterController;
    private Vector3 velocity;

    private bool isGrounded;
    private bool isBoosting;
    private int jumpCounter;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CheckIfGrounded();
        RunForrestRun();
        ProcessJump();

        characterController.Move(velocity * Time.deltaTime);
    }

    private void ProcessJump()
    {       
        if (isGrounded)
            jumpCounter = numberOfJumps;

        if (jumpCounter < 1) 
            return;

        if (Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
            jumpCounter --;
        }
    }

    private void RunForrestRun()
    {
        if (Input.GetKey("d"))
            horizontalSpeed = baseSpeed + boostModifier;
        else
            horizontalSpeed = baseSpeed;
        
        characterController.Move(new Vector3(horizontalSpeed, 0f, 0f) * Time.deltaTime);
    }

    private void CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(transform.position, distanceCheck, groundLayers, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0)
            velocity.y = 0;
        else
            velocity.y += gravity * Time.deltaTime;
    }
}