using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public string playerTag = "Player"; // Tag of the GameObject to follow
    public float speed = 10f;
    public float followDuration = 2f; // Duration in seconds to follow the player
    private Transform playerTransform;
    private Rigidbody2D rb;
    private float lifeTimer; // Timer to track bullet's active duration

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;
        lifeTimer = followDuration;
    }

    private void FixedUpdate()
    {
        if (playerTransform != null)
        {
            Vector3 direction = playerTransform.position - transform.position;
            rb.velocity = direction.normalized * speed;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Update the timer and destroy the bullet if the timer expires
            lifeTimer -= Time.fixedDeltaTime;
            if (lifeTimer <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag(playerTag))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
