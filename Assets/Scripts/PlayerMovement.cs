using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float upwardVelocity;
    Rigidbody2D rb;
    Vector2 velocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(0, upwardVelocity);
    }

    void Update()
    {
       if(Input.GetKey("space"))
        {
            rb.AddForce(velocity);
        }
    }
}
