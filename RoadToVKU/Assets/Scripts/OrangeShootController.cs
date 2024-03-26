using UnityEngine;
using System.Collections;

public class OrangeShootController : MonoBehaviour
{
    public float speed;
    public PlayerController player;
    public GameObject enemyDeathEffect;
    public GameObject impactEffect;
    public int pointsForKill;
    public float rotationSpeed;
    public int damageToGive;

    private Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
            rotationSpeed = -rotationSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        rigidbody2D.angularVelocity = rotationSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            //other.GetComponent<EnemyHealthManager>().giveDamage(this.damageToGive);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}