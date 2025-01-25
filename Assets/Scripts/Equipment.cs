using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Equipment : MonoBehaviour
{
    [SerializeField] private Player_Inventory inventory;
    [SerializeField] private Image slot1;
    [SerializeField] private Image slot2;
    [SerializeField] private Image slot3;
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text descrip;
    [SerializeField] private Image display;

    // Start is called before the first frame update
    void Start()
    {
        if(inventory.slot1){
            slot1.sprite = inventory.slot1.itemSprite;
        }
        if(inventory.slot2){
            slot2.sprite = inventory.slot2.itemSprite;
        }
        if(inventory.slot3){
            slot3.sprite = inventory.slot3.itemSprite;
        }
        display.sprite = inventory.slot1.itemSprite;
        name.text = inventory.slot1.itemName;
        descrip.text = inventory.slot1.itemDescription;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
