using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public BoxCollider2D collider;
    public Rigidbody2D rb;
    private float width;
    public float scrollSpeed;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = collider.size.x;
        //collider.enabled = false;

        rb.velocity = new Vector2(scrollSpeed, 0);


    }
    void Update()
    {
        if (transform.position.x < -width)
        {
            Vector2 resetPos = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPos;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(this.gameObject);
        }
    }
}
