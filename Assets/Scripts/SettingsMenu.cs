using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start() 
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int correctResolution = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height){
                correctResolution = i;
                Debug.Log(i);
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = correctResolution;
        resolutionDropdown.RefreshShownValue();

    }
    public void SetVolume (float volume) 
    {
        //audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality (int qualityIndex) 
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen) 
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution (int resolutionIndex) 
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
