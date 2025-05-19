using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;
using FMOD.Studio;

public class NPCDialogue : MonoBehaviour
{
    private EventInstance dialogueInstance;

    [Header("FMOD Event Paths")]
    [SerializeField] private EventReference idleEvent;
    [SerializeField] private EventReference interactEvent;

    [Header("Idle Dialogue Settings")]
    [SerializeField] private int idleDialogueCount = 3;
    [SerializeField] private float minIdleDelay = 6f;
    [SerializeField] private float maxIdleDelay = 15f;

    private void Start()
    {
        StartCoroutine(IdleDialogueRoutine());
    }

    private IEnumerator IdleDialogueRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minIdleDelay, maxIdleDelay));
            PlayRandomIdleDialogue();
        }
    }

    public void PlayDialogue(EventReference eventRef, int dialogueID)
    {
        dialogueInstance = RuntimeManager.CreateInstance(eventRef);
        dialogueInstance.setParameterByName("Dialogue_ID", dialogueID);

        RuntimeManager.AttachInstanceToGameObject(dialogueInstance, transform, GetComponent<Rigidbody>());

        dialogueInstance.start();
        dialogueInstance.release();
    }

    public void PlayRandomIdleDialogue()
    {
        int randomDialogue = Random.Range(0, idleDialogueCount);
        PlayDialogue(idleEvent, randomDialogue);
    }

    public void PlayInteractionDialogue(int dialogueID)
    {
        PlayDialogue(interactEvent, dialogueID);
    }
}


