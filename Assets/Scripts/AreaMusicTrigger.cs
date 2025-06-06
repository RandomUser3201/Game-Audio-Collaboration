using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaMusicTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.Instance.PlayAreaSound(gameObject.tag);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.Instance.StopMusic();
        }
    }
}
