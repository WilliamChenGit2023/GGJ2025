using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue_Trigger : MonoBehaviour
{

    public NPC_Dialogues dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<Dialogue_Manager>().Start_Dialogue(dialogue);//Repeatable dialogue
    }
}
