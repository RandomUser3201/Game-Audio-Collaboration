using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;
using FMOD.Studio;

public class NPCDialogue : MonoBehaviour
{
    private EventInstance dialogueInstance;

    public void PlayDialogue(string eventPath, int dialogueID)
    {
        dialogueInstance = RuntimeManager.CreateInstance(eventPath);
        dialogueInstance.setParameterByName("Dialogue_ID", dialogueID);
        dialogueInstance.start();
        dialogueInstance.release();
    }

    public void PlayRandomDialogue()
    {
        string NPCDialogue = "TEST";
        int randomDialogue = Random.Range(0, 3);
        PlayDialogue(NPCDialogue, randomDialogue);
    }
}
