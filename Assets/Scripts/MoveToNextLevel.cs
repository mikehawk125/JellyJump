using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "end")
        {
            // game has 6 levels == buildIndex is 8 (menu, map, level1, ...)
            if (SceneManager.GetActiveScene().buildIndex == 8)
            {
                Debug.Log("YOU WIN GAME!");
                // win screen?
            }
            else
            {
                // move to Map scene
                SceneManager.LoadScene("Map");
            }
        }
    }
}
