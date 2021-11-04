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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(0, upwardVelocity);
        step = movementSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (Input.GetKey("space"))
        {
            if (!animator.GetBool("IsJumping"))
                animator.SetBool("IsJumping", true);

            rb.AddForce(velocity);
        }

        /*
        if (rb.velocity.y <= 0)
        {
            animator.SetBool("IsJumping", false);
        }
        */

        float inputX = Input.GetAxis("Horizontal");
        transform.Translate(inputX * step, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("IsJumping", false);
        }
    }
}
