using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string itemName;

    public string itemDescription;
    public Sprite itemSprite; 

    public Item(string n, string d, Sprite s){
        this.itemName = n;
        this.itemDescription = d;
        this.itemSprite = s;
    }
}
