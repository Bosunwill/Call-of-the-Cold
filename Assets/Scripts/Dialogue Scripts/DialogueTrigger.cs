using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    bool playerIsNear = false;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void Update()
    {
        if(playerIsNear)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialogue();
            }
        }
        else
        {
            return;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //if player enters collider E button triggers dialogue
        if(other.gameObject.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        // if player is not in collider dialogue cannot be triggered
        if(other.gameObject.CompareTag("Player"))
        {
            playerIsNear = false;
        }
    }
}
