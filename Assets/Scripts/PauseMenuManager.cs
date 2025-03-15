using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using FMODUnity;
using FMOD.Studio;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject optionsPanel;
    public GameObject audioPanel;
    public GameObject audioU;
    public GameObject audioM;

    public UnityEngine.UI.Slider masterSlider;
    public UnityEngine.UI.Slider musicSlider;
    public UnityEngine.UI.Slider sfxSlider;

    private VCA masterVCA;
    private VCA musicVCA;
    private VCA sfxVCA;

    private bool isMuted = false;
    private float lastVol = 1f;

    // Start is called before the first frame update
    public void Awake()
    {
        menuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        audioPanel.SetActive(false);
        audioM.SetActive(false);

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        
        masterVCA = RuntimeManager.GetVCA("vca:/Master");
        musicVCA = RuntimeManager.GetVCA("vca:/Music");
        sfxVCA = RuntimeManager.GetVCA("vca:/SFX");

        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        SetMasterVolume(masterSlider.value);
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("T pressed");

            if (!menuPanel.activeSelf)
            {
                Debug.Log("Pause Menu Pop-Up");
                menuPanel.SetActive(true);
                Time.timeScale = 0f;
                UnityEngine.Cursor.lockState = CursorLockMode.None; 
                UnityEngine.Cursor.visible = true;
            }

            else
            {
                Debug.Log("Pause Menu Pop-Up");
                menuPanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    // Menu Panel
    public void ResumeButtonF()
    {
        Debug.Log("Resume");
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        if (UnityEngine.Cursor.visible == true)
        {
            UnityEngine.Cursor.visible = false;
        }
        
        menuPanel.SetActive(false);
    }

    public void OptionsButtonF()
    {
        Debug.Log("options");
        menuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void QuitButtonF()
    {
        Debug.Log("quit");
    }

    // Options Panel
    public void AudioButtonF()
    {
        Debug.Log("Audio");
        optionsPanel.SetActive(false);
        audioPanel.SetActive(true);
    }

    public void BackButtonF()
    {
        Debug.Log("Back");
        menuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    // Audio Panel

    public void BackButton2F()
    {
        Debug.Log("back button 2");
        optionsPanel.SetActive(true);
        audioPanel.SetActive(false);
    }

    public void audioToggle()
    {
        if (!isMuted)
        {
            lastVol = masterSlider.value; 
            SetMasterVolume(0f); 
            audioM.SetActive(true); 
            audioU.SetActive(false); 
            isMuted = true; 
        }
        else
        {
            SetMasterVolume(lastVol); 
            masterSlider.value = lastVol;
            audioM.SetActive(false);
            audioU.SetActive(true); 
            isMuted = false;
        }
    }

    // Audio Sliders

    public void SetMasterVolume(float volume)
    {
        masterVCA.setVolume(volume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        musicVCA.setVolume(volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxVCA.setVolume(volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

}
