using UnityEngine;
using System.Collections;

public class FlyerEnemyMove : MonoBehaviour
{
    public float moveSpeed;
    public float playerRange;
    public LayerMask playerLayer;
    public bool playerInRange;
    public bool facingAway;
    public bool followOnLookAway;

    private PlayerController thePlayer;

    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((thePlayer.transform.position.x < transform.position.x && thePlayer.transform.localScale.x < 0)
            || (thePlayer.transform.position.x > transform.position.x && thePlayer.transform.localScale.x > 0))
        {
            facingAway = true;
        }
        else
        {
            facingAway = false;
        }

        if ((followOnLookAway && facingAway) || (!followOnLookAway))
        {
            playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);
            if (playerInRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
            }
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, playerRange);
    }
}