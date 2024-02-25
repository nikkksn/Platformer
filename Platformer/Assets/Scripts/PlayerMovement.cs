using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float JumpForce;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float speed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private AnimationCurve Curve;
    [SerializeField] private float groundCheckRadius = 0.2f;

    [SerializeField] private float JumpOffset;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    [SerializeField] private bool shootCheck;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Vector3 overlapCircleTransform = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed && isGrounded)
        {
            Jump();

        }

        if(direction != 0)
        {
            HorizontalMovement(direction);
        }
        else
        {
                animator.SetBool("IsRunning", false);
        }
    }

    private void Jump()
    {
        if(isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            animator.SetBool("IsJumping", true);
        }
        if(!isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }
    }

    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        animator.SetBool("IsRunning", true);
    }
    public void OnJumpAnimationEnd()
    {
        animator.SetBool("IsJumping", false); 
    }
    public bool ShootCheck
    {
        get { return shootCheck; }
    }

    public void SetIsMirror(bool value)
    {
        animator.SetBool("IsMirror", value);
        shootCheck = value;
    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}
