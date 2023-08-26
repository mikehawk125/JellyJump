using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ScoreText;
    private int ScoreNumber;
    public AudioSource gemCollectSound; // Assign your sound player GameObject with AudioSource here

    void Start()
    {
        ScoreNumber = 0;
        ScoreText.text = "Score: " + ScoreNumber;
    }

    // player touches colectable items (colItems)
    private void OnTriggerEnter2D (Collider2D colItems)
    {
        if(colItems.tag == "Items")
        {
            ScoreNumber++;
            Destroy(colItems.gameObject);
            PlayGemCollectSound();
            ScoreText.text = "Score: " + ScoreNumber.ToString();
        }
    }
    private void PlayGemCollectSound()
    {
        if (gemCollectSound != null)
        {
            gemCollectSound.Play();
        }
    }
}
