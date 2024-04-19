using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startLevel;
    public int playerLives;
    public int playerHealth;

    public void NewGame()
    {
        //PlayerPrefs.SetInt("PlayerCurrentLives", this.playerLives);
        //PlayerPrefs.SetInt("CurrentPlayerScore", 0);
        //PlayerPrefs.SetInt("PlayerCurrentHealth", this.playerHealth);
        //PlayerPrefs.SetInt("PlayerMaxHealth", this.playerHealth);
        Application.LoadLevel(startLevel);
        //SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
