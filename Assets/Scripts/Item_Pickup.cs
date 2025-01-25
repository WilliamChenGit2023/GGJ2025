using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pickup : MonoBehaviour
{
    public void EventTriggered()
    {
        gameObject.SetActive(false); //there could more possiblities for stuff
    }
}
