using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float xInput;
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float jumpForce = 8f;
    [Header("Collision details")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGrounded;

    [Header("Jump settings")]
    [SerializeField] private int maxJumps = 2;
    private int jumpCount;
    private bool wasGroundedPrev;
    private bool jumpPressed = false;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        
        HandleInput();
        HandleColission();
        

    }

    private  void FixedUpdate()
    {
        HandleMovement();

        if (jumpPressed)
        {
            Jump();
            jumpPressed = false;
        }
    }
    private void HandleInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }

    }
    private void HandleMovement()
    {
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
    }
    private void Jump()
    {

        if (isGrounded || jumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount++;
        }
    }
    private void HandleColission()
    {
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - 0.5f);
        isGrounded = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance, whatIsGround);

        if (isGrounded)
        {
            jumpCount = 0;
        }
        wasGroundedPrev = isGrounded;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance));
    }
}