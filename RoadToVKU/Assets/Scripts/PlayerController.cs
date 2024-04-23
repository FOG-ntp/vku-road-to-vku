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
    public GameObject orangerShoot;
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
        myRigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gravityStore = myRigidbody2D.gravityScale;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        //Move && Jump
        if (grounded)
            doubleJumped = false;

        anim.SetBool("Grounded", grounded);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Jump();
        }
        if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }

        //moveVelocity = 0f;

        moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");

        //knockback
        //if (knockbackCount <= 0)
        //{
        //    myRigidbody2D.velocity = new Vector2(moveVelocity, myRigidbody2D.velocity.y);
        //}
        //else
        //{
        //    if (knockFromRight)
        //    {
        //        myRigidbody2D.velocity = new Vector2(-knockback, knockback);
        //    }
        //    else
        //    {
        //        myRigidbody2D.velocity = new Vector2(knockback, knockback);
        //    }
        //    knockbackCount -= Time.deltaTime;
        //}

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = moveSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -moveSpeed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(myRigidbody2D.velocity.x));

        //flipping character
        if (myRigidbody2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
        }

        //shooting
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(orangerShoot, firePoint.position, firePoint.rotation);
            shotDelayCounter = shotDelay;
        }

        if (Input.GetButton("Fire1"))
        {
            shotDelayCounter -= Time.deltaTime;

            if (shotDelayCounter <= 0)
            {
                shotDelayCounter = shotDelay;
                Instantiate(orangerShoot, firePoint.position, firePoint.rotation);
            }
        }
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.transform.tag == "MovingPlatform")
    //    {
    //        transform.parent = other.transform;
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.transform.tag == "MovingPlatform")
    //    {
    //        transform.parent = null;
    //    }
    //}
}
