using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Obstacle : MonoBehaviour
{
    public BoxCollider2D collider;
    public Rigidbody2D rb;
    private float width;
    float scrollSpeed = -12f;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        width = collider.size.x;
        rb.velocity = new Vector2(scrollSpeed, 0);
    }
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Respawn"))
        {
            FindObjectOfType<ObstacleSpawner>().SpawnObstacle();
        }
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(this.gameObject);
        }
    }
}
