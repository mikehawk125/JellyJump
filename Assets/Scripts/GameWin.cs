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
            Time.timeScale = 0f; // Stop animations and updates

            StopAllAudio(); // Stop all audio sources
            AudioManager.Instance.PlaySFX("Game Win SFX");
            scoreHealthCanvas.SetActive(false);
            winMenu.SetActive(true);
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

        // Check if the current scene is a level scene (exclude menus, etc.).
        if (currentSceneBuildIndex > 0)
        {
            // Increment the reached index to unlock the next level.
            int reachedIndex = PlayerPrefs.GetInt("ReachedIndex", 0);
            reachedIndex++;

            // Save the reached index.
            PlayerPrefs.SetInt("ReachedIndex", reachedIndex);

            // Determine the maximum level index you want to unlock (e.g., 6 levels).
            int maxLevelIndex = 6; // Change this value to the maximum level index in your game.

            // Calculate the level to unlock based on the reached index.
            int unlockedLevel = Mathf.Clamp(reachedIndex, 1, maxLevelIndex);

            // Save the unlocked level.
            PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel);

            // Save PlayerPrefs changes.
            PlayerPrefs.Save();
        }
    }
}
