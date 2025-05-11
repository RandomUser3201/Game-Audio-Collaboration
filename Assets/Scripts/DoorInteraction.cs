using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class DoorInteraction : MonoBehaviour
{
    public GameObject KnockPopup;
    public string KnockSound = "event:/SFX/Knock";
    private bool _playerInRange = false;

    void Update()
    {
        if (_playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            RuntimeManager.PlayOneShot(KnockSound, transform.position);
            Debug.Log("Door Knock");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && KnockPopup != null)
        {
            KnockPopup.SetActive(true);
            _playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && KnockPopup != null)
        {
            KnockPopup.SetActive(false);
            _playerInRange = false;
        }
    }
}
