using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public AudioSource audioSource; 
    public AudioClip jumpSound;
    public AudioClip crouchSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJumpSound()
    {
        if (audioSource != null && jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
            audioSource.clip = jumpSound;
            audioSource.Play();
        }
    }

    public void PlayCrouchSound()
    {
        if (audioSource != null && crouchSound != null)
        {
            audioSource.PlayOneShot(crouchSound);
            audioSource.clip = jumpSound;
            audioSource.Play();
        }
    }
}
