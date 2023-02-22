using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    DialogueManager dialogueManager;
    public InteractionEvent interactionEvent;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogueManager.ShowDialogue(interactionEvent.GetDialogues());
        }
    }
}
