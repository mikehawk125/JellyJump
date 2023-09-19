using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource; // Drag your music source here in the Inspector
    public AudioSource sfxSource;   // Drag your SFX source here in the Inspector

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Menu")
        {
            StopMusic();
            PlayMusic("Main Menu Music");
        }
        else if (currentScene.name == "Level1")
        {
            StopMusic();
            PlayMusic("Level 1 Music");
        }
        else if (currentScene.name == "Level2")
        {
            StopMusic();
            PlayMusic("Level 2 Music");
        }
        else if (currentScene.name == "Level3")
        {
            StopMusic();
            PlayMusic("Level 3 Music");
        }
        else if (currentScene.name == "Level4")
        {
            StopMusic();
            PlayMusic("Level 4 Music");
        }
        else if (currentScene.name == "Level5")
        {
            StopMusic();
            PlayMusic("Level 5 Music");
        }
        else if (currentScene.name == "Level6")
        {
            StopMusic();
            PlayMusic("Level 6 Music");
        }
        else if (currentScene.name == "Level7")
        {
            StopMusic();
            PlayMusic("Level 7 Music");
        }
        else if (currentScene.name == "Map")
        {
            StopMusic();
            PlayMusic("Map Music");
        }
        else
        {
            StopMusic();
            PlayMusic("Initial Level Music");
        }
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    public Sound[] music, SFX;

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(music, x => x.name == name);

        if (s == null)
        {
            Debug.Log("No music found.");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(SFX, x => x.name == name);

        if (s == null)
        {
            Debug.Log("No sounds found.");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
