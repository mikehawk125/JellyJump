using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float moveSpeed = 10f;
    private float jumpForce = 3f;
    private int jumpCount = 0; // Tracks the number of jumps performed
    private bool isGrounded = true;
    private float moveHorizontal;
    private float moveVertical;
    public static bool canMove = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
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
        if (Mathf.Abs(moveHorizontal) > 0.1f)
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
            AudioManager.Instance.PlaySFX("Jump SFX");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0; // Reset the jump count when touching the ground
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
