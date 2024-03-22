using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private enum State { idle, run, jump };
        private State state = State.idle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");
        if (hDirection > 0)
        {
            rb.velocity = new Vector2(2, 0);
            transform.localScale = new Vector2(0.1f, 0.1f);
        }
        else if (hDirection < 0)
        {
            rb.velocity = new Vector2(-2, 0);
            transform.localScale = new Vector2(-0.1f, 0.1f);
        }
        else
        {

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, 4f);
            state = State.jump;
        }

        VelocityState();
        anim.SetInteger("State", (int)state);
    }

    private void VelocityState()
    {
        if(state == State.jump)
        {

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
