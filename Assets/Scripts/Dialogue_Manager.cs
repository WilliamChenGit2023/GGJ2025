using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Specialized;

public class Dialogue_Manager : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Animator animator;
    [SerializeField] Player_Interaction player_Interaction;
    private Queue<string> sentences; //FIFO collection (first in first out)

    void Start()
    {
        sentences = new Queue<string>(); //intializes it the Queue
    }
    public void Start_Dialogue(NPC_Dialogues dialogue)
    {
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string dialogues in dialogue.sentences)
        {
            sentences.Enqueue(dialogues);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) // ToCharArray() converts a string to a character array
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        player_Interaction.interacting = false;
    }
}
