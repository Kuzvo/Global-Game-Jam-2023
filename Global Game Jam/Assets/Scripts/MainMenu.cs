using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SetQualityLevel(int index)
    {
        Debug.Log("QUALITY ADJUSTED");
        QualitySettings.SetQualityLevel(index, true);
        if (index == 3)
            Time.fixedDeltaTime = 0.002f;
        else
            Time.fixedDeltaTime = 0.02f;
    }

    public void SetVFXVolume(float value)
    {
        // Set Value
        Debug.Log("VFX ADJUSTED");
        GameManager.Instance.audioManager.SetVolume(value);
    }
    public void SetMusicVolume(float value)
    {
        // Set Value
        Debug.Log("MUSIC ADJUSTED");

        audioMixer.SetFloat("musicVolume", value);
    }

    public void ChangeScreenSettings(int index)
    {
        Debug.Log("DISPLAY ADJUSTED");
        if (index == 0)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else if (index == 1)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
