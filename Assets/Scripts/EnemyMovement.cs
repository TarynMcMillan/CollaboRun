using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    Vector2 movement;
    GameObject player;
    float step;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        step = movementSpeed * Time.deltaTime;
        movement = new Vector2(-1, 0);
    }

    private void FixedUpdate()
    {
        transform.Translate(movement * step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Collider"))
        {
            Destroy(gameObject);
        }
    }

}
