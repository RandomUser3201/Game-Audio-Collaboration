using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using FMODUnity;
using FMOD.Studio;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("References")]
    [SerializeField] private EventReference FootstepEvent;
    [SerializeField] private EventReference ForestEvent;
    [SerializeField] private EventReference VillageEvent;
    [SerializeField] private EventReference Song2Event;
    [SerializeField] private GameObject player;
    public EventInstance areaInstance;
    private CropDetection _cropDetection;

    [Header("Conditions")]
    public bool isWalking = true;
    public bool isCrouching = false;
    public bool isGrounded = false;

    [Header("Footstep Detection")]
    [SerializeField] private float time = 0f;
    [SerializeField] private float rate = 0.45f;
    private string currentSurface;
    public string currentArea = "";
    [SerializeField] private float _raycastDistance = 0.5f;


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

        _cropDetection = GameObject.FindWithTag("Bamboo").GetComponent<CropDetection>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Checks if player is walking
        if (isWalking)
        {
            time += Time.deltaTime;
            //Debug.Log("Walking: " + isWalking);

            // Rate, stops the footstep sounds from playing all at once. Controls time.
            if (time >= rate)
            {
                //Debug.Log("Time: " + time + " Rate: " + rate);
                SurfaceDetection();
                if (isGrounded == true)
                {
                    PlayFootsteps();
                }
                time = 0f;
            }
        }

        Debug.Log("Updated Area Audio" + currentArea);

        // if (Input.GetKeyDown(KeyCode.F))
        // {
        //     PlayFootsteps();
        // }
    }

    public void PlayFootsteps()
    {
        //Debug.Log("Footstep sound played on: " + currentSurface);

        EventInstance footstepInstance = RuntimeManager.CreateInstance(FootstepEvent);
        footstepInstance.setParameterByNameWithLabel("Surfaces", currentSurface);
        footstepInstance.start();
        footstepInstance.release();

        // - Old code - quick testing --
        //RuntimeManager.PlayOneShotAttached(FootstepEvent, player);
        // RuntimeManager.PlayOneShot("event:/Footsteps");
    }

    private void SurfaceDetection()
    {
        RaycastHit hit;
        // if (_cropDetection.inCrop == false)
        // {
        if (Physics.Raycast(player.transform.position, Vector3.down, out hit, _raycastDistance))
        {
            string tag = hit.collider.gameObject.tag;
            currentSurface = tag;
            Debug.Log("Current surface detected: " + currentSurface);
        }
#region --------- TESTING ----------
        //}
        // else if (_cropDetection.inCrop == true)
        // {
        //     currentSurface = "Bamboo";
        // }

        // else if (_cropDetection.inCrop)
        // {
        //     Debug.Log("Else if crop");
        //     RaycastHit hit2;
        //     if (Physics.Raycast(player.transform.position, Vector3.forward, out hit2, _raycastDistance))
        //     {
        //         Debug.Log("Current Surface Bamboo");
        //         currentSurface = "Bamboo";
        //     }
        //     else
        //     {
        //         Debug.Log("Set current surface to tag");
        //         currentSurface = tag;
        //     }
        // }
        #endregion
    }

    public void PlayAreaSound(string newArea)
    {

        if (currentArea == newArea)
        {
            return;
        }

        currentArea = newArea;

        if (areaInstance.isValid())
        {
            areaInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            areaInstance.release();
        }

        switch (newArea)
        {
            case "Forest":
                areaInstance = RuntimeManager.CreateInstance(ForestEvent);
                break;

            case "Village":
                areaInstance = RuntimeManager.CreateInstance(VillageEvent);
                break;

            case "Song2":
                areaInstance = RuntimeManager.CreateInstance(Song2Event);
                break;
        }

        areaInstance.start();
    }

    public void StopMusic()
    {
        if (areaInstance.isValid())
        {
            areaInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            areaInstance.release();
        }
    }

}
