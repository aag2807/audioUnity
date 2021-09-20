using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicUI : MonoBehaviour
{
    public AudioMixer mixer;

    public GameObject window;

    public Slider masterSlider;

    public Slider sfxSlider;

    public Slider musicSlider;

    private void Start()
    {
        window.SetActive(false);

        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            mixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
            mixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
            mixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
            SetSliders();
        }
        else
        {
            SetSliders();
        }
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            window.SetActive(!window.activeInHierarchy);

            if(window.activeInHierarchy)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;

        }    
    }

    void SetSliders()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void updateMasterVolume()
    {
        mixer.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
    }

    public void updateSfxVolume()
    {
        mixer.SetFloat("SFX", sfxSlider.value);
        PlayerPrefs.SetFloat("SFX", sfxSlider.value);
    }

    public void updateMusicVolume()
    {
        mixer.SetFloat("Music", musicSlider.value);
        PlayerPrefs.SetFloat("Music", musicSlider.value);
    }
}
