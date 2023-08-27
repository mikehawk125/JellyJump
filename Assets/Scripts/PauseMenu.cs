using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    // Reference to all audio sources in the scene
    private AudioSource[] allAudioSources;

    void Start()
    {
        pauseMenu.SetActive(false); // invisible when playing game
        allAudioSources = FindObjectsOfType<AudioSource>(); // Get all audio sources in the scene
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true); // pauseMenu visible when pressed Pause
        Time.timeScale = 0f; // stops animations and updates
        PauseAudio();
        isPaused = true;
    }

    public void ResumeGame()
    {
        // opposite from PauseGame
        pauseMenu.SetActive(false); // pauseMenu invisible when pressed Resume
        Time.timeScale = 1f; // starts animations and updates
        ResumeAudio();
        isPaused = false;
    }

    public void GoToMapMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Map");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    private void PauseAudio()
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Pause();
        }
    }

    private void ResumeAudio()
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }
    }
}
