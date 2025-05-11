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
    [SerializeField] private string idleEventPath = "event:/NPC/Dialogue/NPC1";
    [SerializeField] private string interactEventPath = "event:/NPC/InteractionDialogue";

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

    public void PlayDialogue(string eventPath, int dialogueID)
    {
        dialogueInstance = RuntimeManager.CreateInstance(eventPath);
        dialogueInstance.setParameterByName("Dialogue_ID", dialogueID);
        dialogueInstance.start();
        dialogueInstance.release();
    }

    public void PlayRandomIdleDialogue()
    {
        int randomDialogue = Random.Range(0, idleDialogueCount);
        PlayDialogue(idleEventPath, randomDialogue);
    }

    public void PlayInteractionDialogue(int dialogueID)
    {
        PlayDialogue(interactEventPath, dialogueID);
    }
}


