using System;
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

    [SerializeField] private float groundRadius = 0.1f;


    [SerializeField] private LayerMask groundMask;

    private RaycastHit2D[] hits = new RaycastHit2D[1];

    private Bounds playerBounds;
    
    [SerializeField] private int maxPlayerHealth = 100;
    private int currentPlayerHealth;

    public int CurrentPlayerHealth
    {
        get => currentPlayerHealth;
        private set
        {
            if (value > maxPlayerHealth)
                throw new Exception("you can't set the current health value beyond it's max value");
            currentPlayerHealth = value;
            PlayerHealthChange?.Invoke(maxPlayerHealth, CurrentPlayerHealth);
        }
    }

    public event HealthChange PlayerHealthChange;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerBounds = GetComponent<Collider2D>().bounds;
        velocity = new Vector2(0, upwardVelocity);
        step = movementSpeed * Time.fixedDeltaTime;

        CurrentPlayerHealth = maxPlayerHealth;
    }

    private void Update()
    {
        print(IsGrounded());
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

        /*
        if (rb.velocity.y <= 0)
        {
            animator.SetBool("IsJumping", false);
        }
        */

        float inputX = Input.GetAxis("Horizontal");
        transform.Translate(inputX * step, 0, 0);
    }
    private bool IsGrounded()
    {
        var position = transform.position;
        return Physics2D.CircleCastNonAlloc(
            new Vector2(position.x, position.y - playerBounds.extents.y), groundRadius,
            Vector2.down, hits, .1f, groundMask) > 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("IsJumping", false);
        }
    }
    public void TakeDamage(int damage)
    {
        CurrentPlayerHealth -= (damage < CurrentPlayerHealth) ? damage : CurrentPlayerHealth;
    }

    public delegate void HealthChange(int mxHealth, int currHealth);

}


