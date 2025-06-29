using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight = true;
    float jumpPower = 7.5f;

    float mobileInputX = 0f;
    bool mobileJumpPressed = false;

    Rigidbody2D rb;
    Animator animator;

    [SerializeField] Transform groundCheck; // Empty object di bawah kaki
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Gabungkan input keyboard dan mobile
        float inputX = Input.GetAxis("Horizontal") + mobileInputX;
        horizontalInput = Mathf.Clamp(inputX, -1f, 1f);

        FlipSprite();

        if ((Input.GetButtonDown("Jump") || mobileJumpPressed) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            mobileJumpPressed = false; // Reset hanya setelah lompat sukses
        }

        // Ganti animasi
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetInteger("state", 2); // animasi attack misalnya
        }
        else if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            animator.SetInteger("state", 1); // jalan
        }
        else
        {
            animator.SetInteger("state", 0); // idle
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    // ---------------- UI Mobile ----------------

    public void MoveRight(bool isPressed)
    {
        mobileInputX = isPressed ? 1f : 0f;
    }

    public void MoveLeft(bool isPressed)
    {
        mobileInputX = isPressed ? -1f : 0f;
    }

    public void MobileJump()
    {
        mobileJumpPressed = true;
    }
}