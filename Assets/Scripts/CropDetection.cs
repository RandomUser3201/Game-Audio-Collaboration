using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropDetection : MonoBehaviour
{
    public bool inCrop;

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("In Crop");
            inCrop = true;
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("Left Crop");
            inCrop = false;
        }
    }
}
