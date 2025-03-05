using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject optionsPanel;
    public GameObject audioPanel;
    public GameObject audioU;
    public GameObject audioM;

    // Start is called before the first frame update
    public void Awake()
    {
        optionsPanel.SetActive(false);
        audioPanel.SetActive(false);
        audioM.SetActive(false);
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

    // Options
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

    // Audio

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
