using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        animator.SetFloat("verticalMovement", rb.velocity.y);
    }

    public void Move()
    {
        animator.SetBool("run", true);
    }

    public void CancelRun()
    {
        animator.SetBool("run", false);
    }

    public void Jump()
    {
        animator.SetBool("jump", true);
    }

    public void CancelJump()
    {
        animator.SetBool("jump", false);
    }
    
}
