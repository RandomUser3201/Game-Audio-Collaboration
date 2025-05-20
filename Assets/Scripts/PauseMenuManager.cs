using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider dialogueSlider;

    private VCA masterVCA;
    private VCA musicVCA;
    private VCA sfxVCA;
    private VCA dialogueVCA;


    public EventReference ButtonClickSound;

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
        dialogueSlider.onValueChanged.AddListener(SetDialogueVolume);
        
        masterVCA = RuntimeManager.GetVCA("vca:/Master");
        musicVCA = RuntimeManager.GetVCA("vca:/Music");
        sfxVCA = RuntimeManager.GetVCA("vca:/SFX");
        dialogueVCA = RuntimeManager.GetVCA("vca:/Dialogue");

        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        dialogueSlider.value = PlayerPrefs.GetFloat("DialogueVolume", 1f);

        SetMasterVolume(masterSlider.value);
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);
        SetDialogueVolume(dialogueSlider.value);
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
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
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

        if (Cursor.visible == true)
        {
            Cursor.visible = false;
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
        VolumeManager.Instance.ToggleMute();
        bool muted = VolumeManager.Instance.IsMuted();
        if (muted)
        {
            audioM.SetActive(true);
            audioU.SetActive(false);
            masterSlider.value = 0f;
        }
        else
        {
            audioM.SetActive(false);
            audioU.SetActive(true);
            masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
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

    public void SetDialogueVolume(float volume)
    {
        dialogueVCA.setVolume(volume);
        PlayerPrefs.SetFloat("DialogueVolume", volume);
    }

    public void PlayButtonClickSFX()
    {
        RuntimeManager.PlayOneShot(ButtonClickSound);
    }
}
