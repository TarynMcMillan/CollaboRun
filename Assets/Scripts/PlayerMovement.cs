using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    [SerializeField] float upwardVelocity;
    [SerializeField] float movementSpeed;

    Rigidbody2D rb;
    float step;
    Vector2 velocity;

    [SerializeField] private float groundRadius = 0.1f; // this must be greather than 1.68 to work
    [SerializeField] private LayerMask groundMask; // **NEW

    private RaycastHit2D[] hits = new RaycastHit2D[1];

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(0, upwardVelocity);
        step = movementSpeed * Time.fixedDeltaTime;
    }


    private void Update()
    {
        if (IsGrounded())
        {
                animator.SetBool("IsJumping", false);
        }

    }
    void FixedUpdate()
    {
        if (Input.GetKey("space"))
        {
            if (IsGrounded())
            {
                if (!animator.GetBool("IsJumping"))
                    animator.SetBool("IsJumping", true);

                rb.AddForce(velocity);
            }
        }
        

        float inputX = Input.GetAxis("Horizontal");
        transform.Translate(inputX * step, 0, 0);
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("IsJumping", false);
        }
    }

    */

    private bool IsGrounded()
    {
        return Physics2D.CircleCastNonAlloc(transform.position, groundRadius, Vector2.down, hits, 0.1f, groundMask) > 0;
    }
}
