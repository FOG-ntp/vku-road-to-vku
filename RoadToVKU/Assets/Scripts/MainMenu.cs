using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startLevel;
    public int playerLives;
    public int playerHealth;
    public int playerTime;

    public void NewGame()
    {
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
        PlayerPrefs.SetInt("CurrentPlayerScore", 0);
        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
        PlayerPrefs.SetInt("PlayerMaxHealth", playerHealth);
        PlayerPrefs.SetInt("PlayerCurrentTime", playerTime);
        Application.LoadLevel(startLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
