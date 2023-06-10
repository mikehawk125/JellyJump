using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    // array for levels (total 6)
    public Button[] levelButtons;

    void Start()
    {
        // first level at build index 2
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            // non interactable levels 2 and higher
            if (i + 2 > levelAt)
                levelButtons[i].interactable = false;
        }
    }
}
