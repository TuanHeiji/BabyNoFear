using UnityEngine;
using System.Data;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private LayerMask groundLayer;// mặt đất
    [SerializeField] private Transform groundCheck;


    private Animator animator;
    private bool canDoubleJump;
    private bool isGrounded;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //gameManager = FindAnyObjectByType<GameManager>();
        //audioManager = FindAnyObjectByType<AudioManager>();
    }

    void Start()
    {

    }


    void Update()
    {
        //if (gameManager.IsGameOver() || gameManager.IsGameWin())
       // {
        //    return;
        //}
        HandleMovement();
        HandleJump();
        // Die();
        // UpdateAnimation();
        
    }
    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (moveInput > 0) spriteRenderer.flipX = false;
        else if (moveInput < 0) spriteRenderer.flipX = true;
    }

    
    private void HandleJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer); 

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // audioManager.PlayJumbSound();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            canDoubleJump = true;
        }
        else if (Input.GetButtonDown("Jump") && canDoubleJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            canDoubleJump = false;
        }
        
    }

    
    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        bool isJumping = !isGrounded;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
    }

   
}
