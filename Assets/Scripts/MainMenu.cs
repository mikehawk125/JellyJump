using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() // button Play, button Level (1 - 6)
    {
        // loading next Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() // button Quit
    {
        // close application
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
