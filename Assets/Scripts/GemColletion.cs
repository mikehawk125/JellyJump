using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollection : MonoBehaviour
{
    public AudioSource gemCollectSound; // Assign your sound player GameObject with AudioSource here

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Assuming the gem is collected by a player object
        {
            PlayGemCollectSound();
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
