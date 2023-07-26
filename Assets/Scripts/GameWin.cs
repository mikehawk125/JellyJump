using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public GameObject winMenu;

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
}
