using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public GameObject winMenu;
    public static bool isPaused;

    void Start()
    {
        winMenu.SetActive(false); // invisible when playing game
    }

    public void ContinueGame()
    {
        // opposite from PauseGame
        winMenu.SetActive(false); // pauseMenu invisible when pressed Resume
        SceneManager.LoadScene("Map");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0f; // stops animations and updates
            isPaused = true;
            winMenu.SetActive(true);
        }
    }
}
