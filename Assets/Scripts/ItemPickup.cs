using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script allows for ineratcable items around the game to be picked up by the player

public class ItemPickup : Interactables //Inherits from Interactables class
{
    public Item item;
    PlayerStats playerStats;

    public override void Interact() //when health kit interacted with
    {
        base.Interact(); // calls base Interact method from Interactables
        PickUp();
    }

    void PickUp()
    {
        item.Use();
        Destroy(gameObject);
    }
}
    
