using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variavel animator
    public Animator animator;

    //Contador de pulos
    private float jumpCount = 1;

    //Variveis para movimentar o personagem
    public float speed;
    public float jumpforce;
    private float moveInput;
    private Rigidbody2D rb;
    //Variavel para flipar o sprite
    private bool facingRight = true;

    //Variaveis para calcular o pulo
    private bool IsGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpValue;

    //variaveis dash
    IEnumerator dashCoroutine;
    bool isDashing;
    bool canDash = true;
    float direction = 1;
    float normalGravity;

    //variaveis para o Wall Jump e Wall Slide

    [Header("Wall Jump")]
    public float wallJumpTime = 0.2f;
    public float wallSlideSpeed = 0.3f;
    public float wallDistance = 0.5f;
    bool isWallSliding = false;
    RaycastHit2D WallCheckHit;
    float jumpTime;
    void Start() 
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        normalGravity = rb.gravityScale;
    }

    void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        animator.SetBool("Jump", !IsGrounded);
        

        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        //Wall Jumping
        if (facingRight)
        {
            WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, whatIsGround);
        }
        else
        {
            WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0), wallDistance, whatIsGround);
        }
        if (WallCheckHit && !IsGrounded && moveInput !=0)
        {
            isWallSliding = true;
            jumpTime = Time.time + wallJumpTime;
            animator.SetBool("Slide", true);
        }
        else if (jumpTime < Time.time)
        {
            isWallSliding = false;
            animator.SetBool("Slide", false);
        }

        if (isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        }


        moveInput = Input.GetAxis("Horizontal");
        ////////////Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            Flip();
            direction = 1;
        }
        else if(facingRight == true && moveInput < 0)
        {
            Flip();
            direction = -1;
        }

        //dashing

        if(isDashing)
        {
            rb.AddForce(new Vector2(direction * 10,0), ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        // dashing
        //if(moveInput != 0)
        //{
        //    direction = moveInput;
        //}

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
        {
            if (dashCoroutine != null)
            {
                StopCoroutine(dashCoroutine);
            }
            dashCoroutine = Dash(.3f,5);
            StartCoroutine(dashCoroutine);
        }

        if(IsGrounded == true)
        {
            extraJumps = extraJumpValue;
            jumpCount = 0;
            
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0 || isWallSliding && Input.GetKeyDown(KeyCode.UpArrow))
        {  
            animator.SetBool("Jump", true); 
            rb.velocity = Vector2.up * jumpforce;
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && IsGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpCount++;
            Debug.Log(jumpCount);
        }
        //else
        //{
        //    animator.SetBool("IsJumping", false);
        //}

        //Set the yVelocity in the animator
        animator.SetFloat("yVelocity", rb.velocity.y);

        if(jumpCount >= 1 && animator.GetFloat("yVelocity") >= 0)
        {
            animator.SetBool("SecondJump", true);
        }
        else
        {
            animator.SetBool("SecondJump", false);
        }
    }   

    IEnumerator Dash(float dashDuration, float dashCooldown)
    {
        Vector2 originalVelocity = rb.velocity;
        isDashing = true;
        this.tag = "Dashing";
        canDash = false;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        animator.SetBool("Dash", true);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        this.tag = "Player";
        animator.SetBool("Dash", false);
        rb.velocity = originalVelocity;
        rb.gravityScale = normalGravity;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}