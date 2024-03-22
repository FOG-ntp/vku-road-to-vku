using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

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
            anim.SetBool("running", true);
        }
        else if (hDirection < 0)
        {
            rb.velocity = new Vector2(-2, 0);
            transform.localScale = new Vector2(-0.1f, 0.1f);
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, 4f);
        }
    }
}
