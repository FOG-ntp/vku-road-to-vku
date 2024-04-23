using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    //public int startingLives;
    public GameObject gameOverScreen;
    public string mainMenu;
    public float waitAfterGameOver;

    private int lifeCounter;
    private Text theText;
    private PlayerController player;

    // Use this for initialization
    void Start()
    {
        theText = GetComponent<Text>();
        lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeCounter < 0)
        {
            gameOverScreen.SetActive(true);
            player.gameObject.SetActive(false);
        }

        theText.text = "x " + lifeCounter;

        if (gameOverScreen.activeSelf)
        {
            waitAfterGameOver -= Time.deltaTime;
        }

        if (waitAfterGameOver < 0)
        {
            Application.LoadLevel(mainMenu);
        }
    }

    public void GiveLife()
    {
        lifeCounter++;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }

    public void TakeLife()
    {
        lifeCounter--;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }
}