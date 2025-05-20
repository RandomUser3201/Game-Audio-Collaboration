using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class ReverbZone : MonoBehaviour
{
    
    public string snapshotPath;

    private EventInstance snapshotInstance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            snapshotInstance = RuntimeManager.CreateInstance(snapshotPath);
            snapshotInstance.start();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            snapshotInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            snapshotInstance.release();
        }
    }
}