using UnityEngine;
using System.Collections;

public class HurtEnemyOnContact : MonoBehaviour
{
    public int damageToGive;
    public float bounceOnEnemy;

    private Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start()
    {
        rigidbody2D = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, bounceOnEnemy);
        }
    }
}