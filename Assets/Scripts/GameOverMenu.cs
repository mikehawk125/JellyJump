using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;

    void Start()
    {
        gameOverMenu.SetActive(false); // invisible when playing game
    }

    public void RetryGame()
    {
        // opposite from PauseGame
        gameOverMenu.SetActive(false); // pauseMenu invisible when pressed Resume
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
