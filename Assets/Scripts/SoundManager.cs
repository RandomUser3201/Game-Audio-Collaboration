using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using FMODUnity;
using FMOD.Studio;
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] EventReference FootstepEvent;
    [SerializeField] float rate = 0.5f;
    [SerializeField] GameObject player;
    [SerializeField] ThirdPersonUserControl controller;
    public bool isWalking = true;
    public bool isCrouching = false;
    private float time = 0f;

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
        
        if (controller != null && isWalking)
        {
            time += Time.deltaTime;
            Debug.Log("controller not null, walking");

            if (time >= rate)
            {
                Debug.Log("time = 0, play footstep");
                PlayFootsteps();
                time = 0f;
            }   
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayFootsteps();
        }
    }

    public void PlayFootsteps()
    {
        Debug.Log("footstep sound played");
        //RuntimeManager.PlayOneShotAttached(FootstepEvent, player);
        RuntimeManager.PlayOneShot("event:/Footsteps");

        // if (isWalking && isCrouching
        // {

        // })
    }

}
