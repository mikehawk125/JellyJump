using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Added for SceneManager

public class PlayerControl : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    private Transform groundCheck;
    private bool grounded = false;
    private Animator anim;
    public float score;
    private GameObject star;

    void Awake()
    {
        groundCheck = transform.Find("groundCheck");
        anim = GetComponent<Animator>();
        anim.SetBool("ground", false);
    }

    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        anim.SetBool("ground", grounded);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
            anim.SetTrigger("Jump");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.name == "dieCollider") || (col.gameObject.name == "saw"))
        {
            anim.SetTrigger("Die");
        }

        if (col.gameObject.name == "star")
        {
            score++;
            Destroy(col.gameObject);
        }
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Load the current scene
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 65, 30), "Stars: " + score);
    }
}
