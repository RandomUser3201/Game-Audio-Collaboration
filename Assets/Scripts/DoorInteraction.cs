using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.UI;

public class DoorInteraction : MonoBehaviour
{
    public GameObject KnockPopup;
    public Image BgImage;
    public string KnockSound = "event:/SFX/Knock";
    private bool _playerInRange = false;

    void Update()
    {
        // If player is in range and presses 'E', play knock sound
        if (_playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            RuntimeManager.PlayOneShot(KnockSound, transform.position);
            BgImage.color = Color.gray;
            Debug.Log("Door Knock");
        }
        else
        {
            BgImage.color = Color.white;
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
