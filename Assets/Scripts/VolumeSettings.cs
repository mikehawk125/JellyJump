using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private TextMeshProUGUI musicVolumeText;
    [SerializeField] private TextMeshProUGUI SFXVolumeText;

    private void Start()
    {
        LoadVolume();
    }

    public void SetMusicVolume()
    {
        Debug.Log(musicSlider.value);
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume + 0.0001f) * 20);

        if (musicVolumeText != null)
        {
            musicVolumeText.text = Mathf.RoundToInt(volume * 100).ToString();
        }
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume + 0.0001f) * 20);

        if (SFXVolumeText != null)
        {
            SFXVolumeText.text = Mathf.RoundToInt(volume * 100).ToString();
        }
    }

    private void LoadVolume()
    {
        musicSlider.value = 0.25f;
        SFXSlider.value = 0.25f;
        SetMusicVolume();
        SetSFXVolume();
    }
}
