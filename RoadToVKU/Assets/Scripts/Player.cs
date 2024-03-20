using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Private Fields
    Rigidbody2D rb;
    Animator animator;
    public Transform groundCheckCollider;
    public LayerMask groundLayer;

    const float groundCheckRadius = 0.2f;
    //const float overheadCheckRadius = 0.2f;
    //const float wallCheckRadius = 0.2f;
    [SerializeField] float speed = 2;
    [SerializeField] float jumpPower = 500;
    //[SerializeField] float slideFactor = 0.2f;
    //public int totalJumps;
    //int availableJumps;
    float horizontalValue;
    float runSpeedModifier = 2f;
    //float crouchSpeedModifier = 0.5f;

    
    [SerializeField] bool isGrounded;
    bool isRunning;
    bool facingRight = true;
    bool jump;
    bool crouchPressed;
    bool multipleJump;
    bool coyoteJump;
    bool isSliding;
    bool isDead = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Lưu trữ giá trị ngang
        horizontalValue = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontalValue);

        //Nếu LShift đc click thì cho phép isRunning
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }

        //Nếu press Jump button cho phép nhảy 
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }else if (Input.GetButtonUp("Jump"))
        {
            jump= false;
        }
            
    }

    void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue, jump);
    }

    void GroundCheck()
    {
        
        isGrounded = false;
        //Kiểm tra xem GroundCheckObject có va chạm với cái khác không
        //2D Colliders nằm trong "Ground" Layer
        //If yes (isGrounded true) else (isGrounded false)
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
            
    }

   

    void Move(float dir,bool jumpFlag)
    {
        //If the player is grounded and pressed space Jump
        if (isGrounded && jumpFlag)
        {
            isGrounded = false;
            jumpFlag = false;
            //Add jump force
            rb.AddForce(new Vector2(0f,jumpPower));
        }

        #region Move & Run
        //Đặt giá trị của x bằng dir và speed
        float xVal = dir * speed * 100 * Time.fixedDeltaTime;

        // Nếu chúng ta đang chạy nhiều lần với Running modifier (cao hơn)
        if (isRunning)
            xVal *= runSpeedModifier;

        // Tạo Vec2 cho vận tốc
        Vector2 targetVelocity = new Vector2(xVal,rb.velocity.y);
        //Đặt vận tốc của người chơi
        rb.velocity = targetVelocity;

        //Nếu look phải mà click trái (flip sang trái)
        if(facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        //Nếu look trái mà click phải (flip sang phải)
        else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight =true;
        }

        //(0 idle - 4 running)
        // Đặt float xVelocity theo giá trị x của vận tốc RigidBody2D
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        #endregion
    }
}
