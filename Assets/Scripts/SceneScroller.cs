using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScroller : MonoBehaviour
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
        collider.enabled = false;

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
}
