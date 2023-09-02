using UnityEngine;

public class InitializationScript : MonoBehaviour
{
    private void Awake()
    {
        // Set initial PlayerPrefs values if they don't exist yet.
        if (!PlayerPrefs.HasKey("UnlockedLevel"))
        {
            PlayerPrefs.SetInt("UnlockedLevel", 1); // Start with level 1 unlocked.
        }

        if (!PlayerPrefs.HasKey("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", 0); // Start at index 0 (before the first level).
        }

        // Save PlayerPrefs changes.
        PlayerPrefs.Save();
    }
}
