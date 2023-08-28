using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    public TextMeshProUGUI musicVolumeText;
    public TextMeshProUGUI SFXVolumeText; 

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
        musicVolumeText.text = Mathf.RoundToInt(_musicSlider.value * 100).ToString();
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
        SFXVolumeText.text = Mathf.RoundToInt(_sfxSlider.value * 100).ToString();
    }
}
