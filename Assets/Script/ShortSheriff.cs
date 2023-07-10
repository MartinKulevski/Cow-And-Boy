using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortSheriff : MonoBehaviour
{
    public float speed = 2f;

    private Rigidbody2D rb;
    private bool isMovingRight = true;
    private float moveTimer = 0f;
    public float moveDuration = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Move short sheriff to the right
        rb.velocity = new Vector2(speed * (isMovingRight ? 1 : -1), rb.velocity.y);

        // When time is up, move it the opposite direction
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveDuration)
        {
            isMovingRight = !isMovingRight;
            Flip();
            moveTimer = 0f;
        }
    }

    private void Flip()
    {
        //flips sprite depending on where its going
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}

