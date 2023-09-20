using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SavePlayerNameScript : MonoBehaviour
{
    public string playerName;
    public GameObject inputField;
    public TMP_InputField input;


    public void StoreName(string input)
    {
        PlayerPrefs.SetString("PlayerName", input);
        PlayerPrefs.Save();
    }
}
