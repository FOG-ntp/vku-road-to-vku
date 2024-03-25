using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    public GameObject deathParticle;
    public GameObject respawnParticle;
    public float respawnDelay;

    private PlayerController player;
    private Renderer playerRenderer;
    private Rigidbody2D playerRigidbody2D;
    private float gravityStore;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public void RespawnPlayer()
    {
        
    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        playerRenderer.enabled = false;
        
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(this.respawnDelay);
        this.playerRigidbody2D.velocity = new Vector2(0, 0);
        this.player.transform.position = this.currentCheckpoint.transform.position;
        this.player.knockbackCount = 0;
        this.player.enabled = true;
        this.playerRenderer.enabled = true;
        



        player.transform.position = currentCheckpoint.transform.position;
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}
