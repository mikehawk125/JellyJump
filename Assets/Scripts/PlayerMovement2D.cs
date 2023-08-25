using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float moveSpeed;
    private float jumpForce;
    private int jumpCount; // Tracks the number of jumps performed
    private bool isJumping;
    private bool isGrounded;
    private float moveHorizontal;
    private float moveVertical;
    public AudioSource jumpSound;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        moveSpeed = 10f;
        jumpForce = 3f;
        isJumping = false;
        isGrounded = true;
        jumpCount = 0; // Initialize the jump count to 0
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }
    }

    void Jump()
    {
        if (isGrounded || jumpCount < 2) // Allow jumping if on the ground or fewer than 2 jumps performed
        {
            rb2D.AddForce(new Vector2(0f, jumpForce * moveSpeed), ForceMode2D.Impulse);
            jumpCount++;
            jumpSound.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpCount = 0; // Reset the jump count when touching the ground
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
