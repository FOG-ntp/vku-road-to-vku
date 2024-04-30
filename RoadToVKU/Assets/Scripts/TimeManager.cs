using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float startingTime;
    //public GameObject gameOverScreen;

    private Text theText;
    private PauseMenu thePauseMenu;
    //private PlayerController player;
    private float countingTime;
    private HealthManager theHealth;

    // Use this for initialization
    void Start()
    {
        theText = GetComponent<Text>();
        thePauseMenu = FindObjectOfType<PauseMenu>();
        countingTime = startingTime;
        theHealth = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (thePauseMenu.isPaused)
        {

            return;
        }

        countingTime -= Time.deltaTime;

        if (countingTime <= 0)
        {
            theHealth.KillPlayer();
        }

        theText.text = "" + Mathf.Round(countingTime);
    }

    public void ResetTime()
    {
        countingTime = startingTime;
    }

    public void GiveTime()
    {
        countingTime += 5;
        PlayerPrefs.SetFloat("PlayerCurrentTime", countingTime);
    }
}