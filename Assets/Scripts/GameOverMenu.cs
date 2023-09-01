using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject scoreHealthCanvas; // Reference to the score_health canvas

    void Start()
    {
        gameOverMenu.SetActive(false); // Invisible when playing the game
    }

    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true); // Show the game over menu
        scoreHealthCanvas.SetActive(false); // Hide the score_health canvas
        Time.timeScale = 0f; // Stop animations and updates
    }

    public void RetryGame()
    {
        // Opposite from PauseGame
        gameOverMenu.SetActive(false); // Menu invisible when pressed Retry
        scoreHealthCanvas.SetActive(true); // Show the score_health canvas
        Time.timeScale = 1f; // Start animations and updates
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
