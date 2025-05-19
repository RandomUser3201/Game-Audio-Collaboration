using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMODUnity;
using FMOD.Studio;

public class MainMenuManager : MonoBehaviour
{
    [Header("References")]
    public GameObject menuPanel;
    public GameObject optionsPanel;
    public GameObject audioPanel;
    public GameObject audioU;
    public GameObject audioM;
    public EventReference ButtonClickSound;

    [Header("Sliders")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("VCA")]
    private VCA masterVCA;
    private VCA musicVCA;
    private VCA sfxVCA;



    // Start is called before the first frame update
    public void Awake()
    {
        optionsPanel.SetActive(false);
        audioPanel.SetActive(false);
        audioM.SetActive(false);
        
        masterVCA = RuntimeManager.GetVCA("vca:/Master");
        musicVCA = RuntimeManager.GetVCA("vca:/Music");
        sfxVCA = RuntimeManager.GetVCA("vca:/SFX");
    }

    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        masterSlider.onValueChanged.AddListener((v) => VolumeManager.Instance.SetMasterVolume(v));
        musicSlider.onValueChanged.AddListener((v) => VolumeManager.Instance.SetMusicVolume(v));
        sfxSlider.onValueChanged.AddListener((v) => VolumeManager.Instance.SetSFXVolume(v));
    }

    // Menu Panel
    public void StartButtonF()
    {
        Debug.Log("START");
        SceneManager.LoadScene("Demo");
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

    public void AudioToggle()
    {
        VolumeManager.Instance.ToggleMute();

        bool isMuted = VolumeManager.Instance.IsMuted();
        if (isMuted)
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

    public void PlayButtonClickSFX()
    {
        RuntimeManager.PlayOneShot(ButtonClickSound);
    }
    
}
