using UnityEngine;
using System.Collections;

public class ShootAtPlayerInRange : MonoBehaviour
{
    public float playerRange;
    public GameObject enemyShoot;
    public PlayerController player;
    public Transform launchPoint;
    public float waitBetweenShots;

    private float shotCounter;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        shotCounter = waitBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));
        shotCounter -= Time.deltaTime;

        if (shotCounter < 0)
        {
            if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange)
            {
                Shoot();
            }

            if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(enemyShoot, launchPoint.position, launchPoint.rotation);
        shotCounter = waitBetweenShots;
    }
}