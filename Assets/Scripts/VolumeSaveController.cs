using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSaveController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private TMP_Text volumeTextUI = null;

    private void Start()
    {
        LoadValues();
    }

    public void VolumeSlider(float volume)
    {
        float percentage = volume * 100f;
        volumeTextUI.text = Mathf.Round(percentage).ToString("0") + "%";
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    private void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue", 0.50f); // Use 0.5f as the default value if not found
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
        VolumeSlider(volumeValue);
    }
}
