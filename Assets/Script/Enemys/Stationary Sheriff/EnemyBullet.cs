using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject player; 
    public float speed = 10f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {       
        //Move bullet towards player
        Vector3 direction = player.transform.position - transform.position; //Gets player direction
        rb.velocity = direction.normalized * speed; //Moves the bullet torwards the players direction 

        //Rotate bullet towards player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //Gets angle between player and bullet and converts it to degrees
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //Makes the rotation happen with the player
        Destroy(gameObject, 2f); //Destroy gameobject after 2 seconds.
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
