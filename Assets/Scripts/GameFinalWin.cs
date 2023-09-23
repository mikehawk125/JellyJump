using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinalWin : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject scoreHealthCanvas; // Reference to the score_health canvas

    // Reference to all audio sources in the scene
    private AudioSource[] allAudioSources;

    void Start()
    {
        winMenu.SetActive(false); // Invisible when playing the game
        allAudioSources = FindObjectsOfType<AudioSource>(); // Get all audio sources in the scene
    }

    public void Continue()
    {
        SceneManager.LoadScene("Storyboard/Story kraj/Kraj");
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
            scoreHealthCanvas.SetActive(false);
            winMenu.SetActive(true);

            GetComponent<StarsHandler>().starsAcheived();
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
