using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public GameObject winMenu;

    // Reference to all audio sources in the scene
    private AudioSource[] allAudioSources;

    void Start()
    {
        winMenu.SetActive(false); // Invisible when playing the game
        allAudioSources = FindObjectsOfType<AudioSource>(); // Get all audio sources in the scene
    }

    public void ContinueGame()
    {
        // Opposite from PauseGame
        winMenu.SetActive(false); // Menu invisible when pressed Continue
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
            Time.timeScale = 0f; // Stop animations and updates

            StopAllAudio(); // Stop all audio sources
            AudioManager.Instance.PlaySFX("Game Win SFX");
            winMenu.SetActive(true); // Show the win menu
        }
    }

    private void StopAllAudio()
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Stop(); // Stop each audio source
        }
    }
}
