using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        // Load the specified level (change the level name as needed).
        Time.timeScale = 1;
        SceneManager.LoadScene("Level0");
    }

    public void Quit()
    {
        // Quit the application. This will work in a standalone build.
        Application.Quit();
    }
}
