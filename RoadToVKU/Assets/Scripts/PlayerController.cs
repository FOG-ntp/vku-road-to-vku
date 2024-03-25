using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public Transform firePoint;
    public GameObject ninjaStar;
    public float shotDelay;
    public float knockback;
    public float knockbackLength;
    public bool knockFromRight;
    public float knockbackCount;
    public bool onLadder;
    public float climbSpeed;

    private Rigidbody2D myRigidbody2D;
    private bool grounded;
    private bool doubleJumped;
    private Animator anim;
    private float moveVelocity;
    private float shotDelayCounter;
    private float climbVelocity;
    private float gravityStore;

    // Start is called before the first frame update
    void Start()
    {
        this.myRigidbody2D = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
        this.gravityStore = this.myRigidbody2D.gravityScale;
    }

    void FixedUpdate()
    {
        this.grounded = Physics2D.OverlapCircle(this.groundCheck.position, this.groundCheckRadius, this.whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        //di chuyen
        if (grounded)
            doubleJumped = false;

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !doubleJumped && !grounded)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            Jump();
            doubleJumped = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        //this.myRigidbody2D.velocity = new Vector2(this.myRigidbody2D.velocity.x, this.jumpHeight);
    }
}
