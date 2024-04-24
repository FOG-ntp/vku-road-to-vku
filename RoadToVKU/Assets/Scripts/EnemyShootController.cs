using UnityEngine;
using System.Collections;

public class EnemyShootController : MonoBehaviour
{
    public float speed;
    public PlayerController player;
    public GameObject impactEffect;
    public float rotationSpeed;
    public int damageToGive;

    private Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        if (player.transform.position.x < transform.position.x)
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
        if (other.name == "Player")
        {
            //Destroy(other.gameObject);
            HealthManager.HurtPlayer(damageToGive);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
