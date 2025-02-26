using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using FMODUnity;
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] EventReference FootstepEvent;
    [SerializeField] float rate;
    [SerializeField] GameObject player;
    [SerializeField] ThirdPersonUserControl controller;
    public bool isWalking = true;
    float time;

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
        // time = Time.deltaTime;
        
        // if (isWalking && time >= rate)
        // {
        //     PlayFootsteps();
        //     time = 0; // Reset time properly
        // }

        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayFootsteps();
        }
    }

    public void PlayFootsteps()
    {
        Debug.Log("footstep sound played");
        // RuntimeManager.PlayOneShotAttached(FootstepEvent, player);
        RuntimeManager.PlayOneShot("event:/Footsteps");

    }
}
