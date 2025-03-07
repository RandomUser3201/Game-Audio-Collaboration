using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
public class PauseMenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject optionsPanel;
    public GameObject audioPanel;
    public GameObject audioU;
    public GameObject audioM;


    // Start is called before the first frame update
    public void Awake()
    {
        menuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        audioPanel.SetActive(false);
        audioM.SetActive(false);
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
        audioM.SetActive(true);
        audioU.SetActive(false);
    }
}
