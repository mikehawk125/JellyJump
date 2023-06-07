using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed; // player speed
    public float jumpForce;

    public int jumpsAmount;
    int jumpsLeft;
    public Transform GroundCheck; // circle collider
    public LayerMask GroundLayer;

    bool isGrounded; 

    float moveInput;
    Rigidbody2D rb2d;
    float scaleX;

    void Start()
    {
        // on start - fetching player
        rb2d = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;
    }


    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        Flip();
        rb2d.velocity = new Vector2(moveInput * moveSpeed, rb2d.velocity.y);
    }

    public void Flip()
    {
        // moving to the right
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        // moving to the left
        if (moveInput < 0)
        {
            transform.localScale = new Vector3((-1) * scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    public void Jump()
    {
        // check if space tab is hit
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckIfGrounded();
            if (jumpsLeft > 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                jumpsLeft--; // decreasing jumps
            }
        }
    }

    public void CheckIfGrounded()
    {
        // is grounded when circle collider detect collision
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);
        ResetJumps();
    }

    public void ResetJumps()
    {
        // when hits the ground, number of jumps reset
        if (isGrounded)
        {
            jumpsLeft = jumpsAmount;
        }
    }
}