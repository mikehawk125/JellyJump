using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionOpenSound : MonoBehaviour
{
    public AudioSource menuOpenSound; // Reference to the AudioSource component for the menu open sound effect

    public void PlayMenuOpenSound()
    {
        menuOpenSound.PlayOneShot(menuOpenSound.clip);
    }
}
