using UnityEngine;
using UnityEngine.UI;

public class ToggleSlider : MonoBehaviour
{
    public Toggle musicToggle; 
    public Toggle sfxToggle;   
    public Slider musicSlider; 
    public Slider sfxSlider;
    private VolumeSettings volumeSettings;

    private void Start()
    {
        // Attach listeners to the Toggles' onValueChanged events
        musicToggle.onValueChanged.AddListener(OnMusicToggleValueChanged);
        sfxToggle.onValueChanged.AddListener(OnSFXToggleValueChanged);
        volumeSettings = GetComponent<VolumeSettings>();

        // Set initial toggle states based on sliders' values
        musicToggle.isOn = (musicSlider.value == 0);
        sfxToggle.isOn = (sfxSlider.value == 0);
    }

    public void OnMusicToggleValueChanged(bool newValue)
    {
        if (newValue) 
        {
            musicSlider.value = 0;
        }
        else 
        {
            musicSlider.value = 50; 
        }
        volumeSettings.SetMusicVolume();
    }

    public void OnSFXToggleValueChanged(bool newValue)
    {
        if (newValue) 
        {
            sfxSlider.value = 0; 
        }
        else 
        {
            sfxSlider.value = 50; 
        }
        volumeSettings.SetSFXVolume();
    }

    public void OnMusicSliderValueChange()
    {
        
        if (musicSlider.value > 0)
        {
            musicToggle.isOn = false;
        }
        else
        {
            musicToggle.isOn = true;
        }
    }

    public void OnSFXSliderValueChange()
    {

        if (sfxSlider.value > 0)
        {
            sfxToggle.isOn = false;
        }
        else
        {
            sfxToggle.isOn = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false); 
        }
    }
}
