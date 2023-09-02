using UnityEngine;

public class ClearPlayerPrefs : MonoBehaviour
{
    void Awake()
    {
        PlayerPrefs.DeleteAll(); // Clear all PlayerPrefs data.
        PlayerPrefs.Save(); // Save the changes.
    }
}
