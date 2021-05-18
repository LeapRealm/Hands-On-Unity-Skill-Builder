using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] public bool isActiveBool = false;
    [SerializeField] private GameObject downArrow;
    [SerializeField] private Rigidbody2D myRigidBody;

    private Vector2 moveDirection;
    private SpriteRenderer mySpriteRenderer;

    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ProcessInputs();
        Jump();
        ActiveArrow();
    }

    private void FixedUpdate()
    {
        playerMovement();
    }

    private void ProcessInputs()
    {
        if (!isActiveBool) { return; }

        float moveX = Input.GetAxisRaw("Horizontal");

        moveDirection = new Vector2(moveX, myRigidBody.velocity.y);
    }

    private void playerMovement()
    {
        if (!isActiveBool) { return; }

        myRigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, myRigidBody.velocity.y);
    }

    private void Jump()
    {
        if (!isActiveBool) { return; }

        if (!myRigidBody.IsTouchingLayers(LayerMask.GetMask("Foreground", "Block")))
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }

    private void ActiveArrow()
    {
        if (isActiveBool)
        {
            downArrow.SetActive(true);
        }
        else
        {
            downArrow.SetActive(false);
        }
    }
}