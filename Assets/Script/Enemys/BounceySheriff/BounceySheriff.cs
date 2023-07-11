using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceySheriff : MonoBehaviour
{
    public float bounceForce = 10f;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized; //Basically creates a new vector2 direction and uses a random range to figure out the direction of where it bounces
            GetComponent<Rigidbody2D>().velocity = randomDirection * bounceForce; //make the velocity of Bouncey Sheriff = to the random direction as well as the bounce force of the enemy :)
        }
    }
}


