using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    private enum State { idle, run, jump, falling };
    private State state = State.idle;

    [SerializeField] private LayerMask Ground;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");

        if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(0.1f, 0.1f);
        }
        else if (hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-0.1f, 0.1f);
        }
        else
        {

        }
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(Ground)) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.jump;
        }

        VelocityState();
        anim.SetInteger("State", (int)state);
    }

    private void VelocityState()
    {
        //animation jumping
        if (state == State.jump)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }

        //animation falling
        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(Ground))
            {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.run;
        }
        else
        {
            state = State.idle;
        }
    }
}
