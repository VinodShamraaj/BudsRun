using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 400f;
    [SerializeField] private float moveSpeed = 100f;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundChecker;

    public UnityEvent OnLandEvent;

    private bool isGrounded;
    private float groundedRadius = 0.2f;
    private Rigidbody2D rb;
    private Vector3 m_Velocity = Vector3.zero;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

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

    public void Move(bool jump)
    {
        Vector3 targetVelocity = new Vector2(moveSpeed * Time.fixedDeltaTime * 10f, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, movementSmoothing);

        if (jump)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }
}
