using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    Vector2 movement;
    GameObject player;
    float step;
    [SerializeField] private int damage = 25;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        step = movementSpeed * Time.fixedDeltaTime;
        movement = new Vector2(-1, 0);
    }

    private void FixedUpdate()
    {
        transform.Translate(movement * step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Player"))
       {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(damage);
       }
       else if (collision.gameObject.CompareTag("Boundary"))
       {
            Destroy(gameObject);
       }
    }

}
