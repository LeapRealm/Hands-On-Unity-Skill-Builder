﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject hitSpot;
    [SerializeField] private GameObject targetBlock;
    
    private Vector2 moveDirection;

    private void Update()
    {
        ProcessInputs();
        Swing();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        if (Input.GetAxisRaw("Horizontal") > 0)
            GetComponent<SpriteRenderer>().flipX = false;
        else if (Input.GetAxisRaw("Horizontal") < 0)
            GetComponent<SpriteRenderer>().flipX = true;
    }

    private void Swing()
    {
        if (Input.GetMouseButton(0))
            animator.SetBool("Swing", true);

        if (Input.GetMouseButtonUp(0))
            animator.SetBool("Swing", false);
    }

    public void HitBlock()
    {
        Destroy(targetBlock);
        targetBlock = null;
    }

    public void SetTargetBlock(GameObject currentBlock)
    {
        targetBlock = currentBlock;
    }
}