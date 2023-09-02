using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
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
        SceneManager.LoadScene("Map");
        UnlockNewLevel();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            UnlockNewLevel();

            Time.timeScale = 0f; // Stop animations and updates

            StopAllAudio(); // Stop all audio sources
            AudioManager.Instance.PlaySFX("Game Win SFX");
            scoreHealthCanvas.SetActive(false);
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

    void UnlockNewLevel()
    {
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        // Increment the reached index to unlock the next level.
        int reachedIndex = PlayerPrefs.GetInt("ReachedIndex", 0);
        reachedIndex++;

        // Save the reached index.
        PlayerPrefs.SetInt("ReachedIndex", reachedIndex);

        // Increment the unlocked level if it's less than the reached index.
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        if (unlockedLevel < reachedIndex)
        {
            unlockedLevel++;
            PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel);
        }

        // Save PlayerPrefs changes.
        PlayerPrefs.Save();
    }


}
