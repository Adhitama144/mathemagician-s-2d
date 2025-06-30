using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight = true;
    float jumpPower = 7.5f;

    // Mobile Input
    float mobileInputX = 0f;

    // Jump buffer
    bool jumpRequested = false;

    // Components
    Rigidbody2D rb;
    Animator animator;

    // Ground Check
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Combine keyboard + mobile input
        float inputX = Input.GetAxis("Horizontal") + mobileInputX;
        horizontalInput = Mathf.Clamp(inputX, -1f, 1f);

        // Flip sprite
        FlipSprite();

        // Check for jump input (keyboard)
        if (Input.GetButtonDown("Jump"))
        {
            jumpRequested = true;
        }

        // Animations
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetInteger("state", 2);
        }
        else if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            animator.SetInteger("state", 1);
        }
        else
        {
            animator.SetInteger("state", 0);
        }
    }

    void FixedUpdate()
    {
        // Horizontal movement
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Jump execution
        if (jumpRequested && IsGrounded())
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, jumpPower);
            jumpRequested = false;
        }
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

    // ---------- UI Mobile ----------

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
        jumpRequested = true;
    }
}