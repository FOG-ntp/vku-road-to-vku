using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public GameObject currentCheckpoint;
    public GameObject deathParticle;
    public GameObject respawnParticle;
    public float respawnDelay;
    public int pointPenaltyOnDeath;
    //public HealthManager healthManager;

    private PlayerController player;
    private Renderer playerRenderer;
    private Rigidbody2D playerRigidbody2D;
    private float gravityStore;
    private CameraController camera;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        playerRenderer = player.GetComponent<Renderer>();
        playerRigidbody2D = player.GetComponent<Rigidbody2D>();
        camera = FindObjectOfType<CameraController>();
        //this.healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        playerRenderer.enabled = false;
        camera.isFollowing = false;
        ScoreManager.AddPoints(-pointPenaltyOnDeath);
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);
        playerRigidbody2D.velocity = new Vector2(0, 0);
        player.transform.position = currentCheckpoint.transform.position;
        player.knockbackCount = 0;
        player.enabled = true;
        playerRenderer.enabled = true;
        //this.healthManager.FullHealth();
        //this.healthManager.isDead = false;
        camera.isFollowing = true;
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}