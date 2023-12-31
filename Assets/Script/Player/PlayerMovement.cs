using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    private float horizontalInput;
    public bool isGrounded = true;
    public float Power = 10f;
    public bool canJump = true;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriterenderer;
    public Animator animator;
    private bool isJumping = false; 

    public AudioClip jumpAudioClip;  // Reference to the jump audio clip
    private AudioSource audioSource;  // Reference to the AudioSource component


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

        audioSource.clip = jumpAudioClip;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) //If collision is touching ground, turn on booleans.
        {
            isGrounded = true;
            canJump = true;
            isJumping = false;
            print("Is Grounded");
        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) //If collision isnt touching ground, turn off booleans
        {
            isGrounded = false;
            canJump = false;
            isJumping = true; 
            print("Not Grounded");
        }
    }

    // Update is called once per frame


    void Jump()
    {
        rb2d.AddForce(new Vector2(0f, Power), ForceMode2D.Impulse);
        isJumping = true;

        // Play the jump audio
        audioSource.Play();
    }

    void Sprint() //Make player sprint
    {
        speed = 10f;

    }

    void Walk()
    {
        speed = 5f;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift)) //If Lshift is held down , increase speeds
        {
            Sprint();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) // If Lshift is up, Decrease back to normal speed
        {
            Walk();
        }

        animator.SetBool("isJumping", isJumping);


        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0) //If horizontal input is lower then 0 
        {
            spriterenderer.flipX = horizontalInput < 0f; //flip sprite

            animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        }

        else
        {
            animator.SetFloat("Speed", 0f);
        }
        //Controls
        transform.Translate(Vector2.right * speed * Time.deltaTime * horizontalInput); //Make player move left and right
        if (isGrounded && canJump && Input.GetButtonDown("Jump")) //If all these equal true
        {
            Jump(); //Make player Jump
        }
    }
}