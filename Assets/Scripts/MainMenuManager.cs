using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject optionsPanel;

    // Start is called before the first frame update
    public void Awake()
    {
        optionsPanel.SetActive(false);
    }

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

    public void AudioButtonF()
    {
        Debug.Log("Audio");
    }

    public void BackButtonF()
    {
        Debug.Log("Back");
        menuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void QuitButtonF()
    {
        Debug.Log("quit");
    }
}
