using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int playerHealth;

    public int maxPlayerHealth;
    //public Text text;
    public Slider healthBar;
    public bool isDead;

    private LevelManager levelManager;
    private LifeManager lifeSystem;
    private TimeManager theTime;

    // Use this for initialization
    void Start()
    {
        //this.text = GetComponent<Text>();
        healthBar = GetComponent<Slider>();

        HealthManager.playerHealth = maxPlayerHealth;
        HealthManager.playerHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");
        levelManager = FindObjectOfType<LevelManager>();
        isDead = false;
        lifeSystem = FindObjectOfType<LifeManager>();
        theTime = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthManager.playerHealth <= 0 && !this.isDead)
        {
            HealthManager.playerHealth = 0;
            levelManager.RespawnPlayer();
            isDead = true;
            lifeSystem.TakeLife();
            theTime.ResetTime();
        }

        //this.text.text = "" + HealthManager.playerHealth;
        healthBar.value = HealthManager.playerHealth;
    }

    public static void HurtPlayer(int damageToGive)
    {
        HealthManager.playerHealth -= damageToGive;
        PlayerPrefs.SetInt("PlayerCurrentHealth", HealthManager.playerHealth);
    }

    public void FullHealth()
    {
        HealthManager.playerHealth = PlayerPrefs.GetInt("PlayerMaxHealth");
        PlayerPrefs.SetInt("PlayerCurrentHealth", HealthManager.playerHealth);
    }

    public void KillPlayer()
    {
        HealthManager.playerHealth = 0;

    }
}
