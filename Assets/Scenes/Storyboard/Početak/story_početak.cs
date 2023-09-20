using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class story_početak : MonoBehaviour
{
    // Određena scena
    void OnEnable()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

}
