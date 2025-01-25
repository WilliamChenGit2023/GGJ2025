using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Player_Inventory : MonoBehaviour
    {
        public List<Item> Inventory;
        public Item slot1;
        public Item slot2;
        public Item slot3;

        [SerializeField] Sprite test;
        
        void Start(){
            Inventory.Add(new Item("disembodied hand", "this is a hand", test));
            slot1 = Inventory[0];
        }
    }
