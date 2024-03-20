using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Public Feilds
    public float speed = 1;

    //Private Fields
    Rigidbody2D rb;
    Animator animator;
    public Transform groundCheckCollider;
    public LayerMask groundLayer;

    const float groundCheckRadius = 0.2f;
    float horizontalValue;
    float runSpeedModifier = 2f;
    public int totalJumps;
    int availableJumps;

    bool isGrounded = false;
    bool isRunning=false;
    bool facingRight = true;

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
    }

    void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue);
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

    void Move(float dir)
    {
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

    }
}
