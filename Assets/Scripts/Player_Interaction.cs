using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    [SerializeField] private LayerMask NPC;
    [SerializeField] private LayerMask items;
    [SerializeField] private float interactRange = 1f;
    public string heldItem = "none";
    public bool interacting = false;
    private string currentNPC;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] interactableNPC = Physics2D.OverlapCircleAll(transform.position, interactRange, NPC);
        Collider2D[] interactableItems = Physics2D.OverlapCircleAll(transform.position, interactRange, items);
        if (interacting && Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Collider2D my_NPC in interactableNPC)
            {
                FindObjectOfType<Dialogue_Manager>().DisplayNextSentence();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Collider2D my_NPC in interactableNPC)
            {
                my_NPC.GetComponent<NPC_Dialogue_Trigger>().TriggerDialogue();
                currentNPC = my_NPC.name;
                interacting = true;
            }
            foreach (Collider2D item in interactableItems)
            {
                item.GetComponent<Item_Pickup>().EventTriggered();
                heldItem = item.name;
                Debug.Log(heldItem);
            }
            
        }
        else
        {
            foreach (Collider2D my_NPC in interactableNPC)
            {
                if (my_NPC.name != currentNPC)
                {
                    interacting = false;
                }
            }
        }
    }
}
