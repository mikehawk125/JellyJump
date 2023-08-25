using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private bool isFacingRight = true;

    private Rigidbody2D _rigidBody;
    [SerializeField] private LayerMask _groundLayer;

    RaycastHit2D hitFacing;
    RaycastHit2D hitDown;

    public Transform checkPOS;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 downStartPos = checkPOS.position;

        Debug.DrawRay(downStartPos, (isFacingRight ? Vector2.right : Vector2.left) * 2f);
        Debug.DrawRay(downStartPos, Vector2.down * 2f);

        hitFacing = Physics2D.Raycast(downStartPos, isFacingRight ? Vector2.right : Vector2.left, 2f, _groundLayer);
        hitDown = Physics2D.Raycast(downStartPos, Vector2.down, 2f, _groundLayer);

        if (hitFacing || !hitDown)
            Flip();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(isFacingRight ? speed : -speed, _rigidBody.velocity.y);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}