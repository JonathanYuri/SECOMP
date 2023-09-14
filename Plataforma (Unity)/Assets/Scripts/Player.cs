using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    AnimatorController animator;
    [SerializeField] float velocity;
    [SerializeField] float jumpVelocity;

    bool isFloor = true;
    bool jump = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<AnimatorController>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (isFloor)
            {
                jump = true;
            }
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput == 0f)
        {
            animator.CancelRun();
        }
        else
        {
            animator.Move();
        }
        rb.velocity = new(horizontalInput * velocity * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Jump()
    {
        animator.Jump();
        rb.velocity = new(rb.velocity.x, jumpVelocity);
        isFloor = false;
        jump = false;
    }

    private void FixedUpdate()
    {
        Move();

        if (jump)
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            animator.CancelJump();
            isFloor = true;
        }
        else if (collision.collider.CompareTag("Enemy"))
        {
            Jump();
        }
    }
}
 