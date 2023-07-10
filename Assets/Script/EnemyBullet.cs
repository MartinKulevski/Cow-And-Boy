using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject player; 
    public float speed = 10f;
    private Rigidbody2D rb;
    public float distanceFromPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {       //Finds the direction on where the player is

        distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;

            //Finds the angle using Atan2 and uses Rad2Dag to convert to degrees and AngleAxis to rotate to the player.
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //Make direction normal ;)
            direction.Normalize();

            //Move bullet to the player
            //transform.Translate (direction * speed * Time.deltaTime);
    }
}
