using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.Rendering;
public class VolumeManager : MonoBehaviour
{
    public static VolumeManager Instance;

    private VCA masterVCA;
    private VCA musicVCA;
    private VCA sfxVCA;
    private VCA dialogueVCA;


    private bool isMuted = false;
    private float previousMasterVolume = 1f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        masterVCA = RuntimeManager.GetVCA("vca:/Master");
        musicVCA = RuntimeManager.GetVCA("vca:/Music");
        sfxVCA = RuntimeManager.GetVCA("vca:/SFX");
        dialogueVCA = RuntimeManager.GetVCA("vca:/Dialogue");

        float savedMaster = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float savedMusic = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float savedSFX = PlayerPrefs.GetFloat("SFXVolume", 1f);
        float savedDialogue = PlayerPrefs.GetFloat("DialogueVolume", 1f);

        isMuted = PlayerPrefs.GetInt("IsMuted", 0) == 1;

        previousMasterVolume = savedMaster;

        if (isMuted)
        {
            masterVCA.setVolume(0f);
        }
        else
        {
            masterVCA.setVolume(savedMaster);
        }

        musicVCA.setVolume(savedMusic);
        sfxVCA.setVolume(savedSFX);
        dialogueVCA.setVolume(savedDialogue);
    }

    public void SetMasterVolume(float volume)
    {
        if (!isMuted)
        {
            masterVCA.setVolume(volume);
            previousMasterVolume = volume;
            PlayerPrefs.SetFloat("MasterVolume", volume);
        }
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

    public void ToggleMute()
    {
        if (!isMuted)
        {
            masterVCA.getVolume(out previousMasterVolume);
            masterVCA.setVolume(0f);
            isMuted = true;
        }
        else
        {
            masterVCA.setVolume(previousMasterVolume);
            isMuted = false;
        }

        PlayerPrefs.SetInt("IsMuted", isMuted ? 1 : 0);
        PlayerPrefs.SetFloat("MasterVolume", previousMasterVolume);
    }
    
    public bool IsMuted()
    {
        return isMuted;
    }
}
