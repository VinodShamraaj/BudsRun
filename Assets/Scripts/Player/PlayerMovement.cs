using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private float jumpTime = 100f;
    [Range(0, .3f)][SerializeField] private float movementSmoothing = .05f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundChecker;

    public UnityEvent OnLandEvent;

    private bool isGrounded;
    private bool isJumping;
    private float groundedRadius = 0.2f;
    private float jumpTimeCounter = 0;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 velocity = Vector3.zero;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundChecker.position, groundedRadius, groundLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
                if (!wasGrounded)
                {
                    OnLandEvent.Invoke();
                }

            }
        }
    }

    public void Move(bool jumpStart, bool jumpHold, bool jumpEnd)
    {
        Vector3 targetVelocity = new Vector2(moveSpeed * Time.fixedDeltaTime * 10f, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);

        if (isGrounded && jumpStart)
        {
            animator.SetBool("IsJump", true);
            isJumping = true;
            

            jumpTimeCounter = jumpTime;

            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce));
        }

        if (jumpHold)
        {
            if (jumpTimeCounter > 0 && isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                jumpTimeCounter -= Time.deltaTime;
            }
            else{
                animator.SetBool("IsJump", false);
            }
        }

        if (jumpEnd)
        {
            isJumping = false;
            animator.SetBool("IsJump", false);
        }
    }
}
