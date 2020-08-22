using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script allows for ineratcable items around the game to be picked up by the player

public class ItemPickup : Interactables //Inherits from Interactables class
{
    public Item item; //creates an a blank item object called item
    PlayerStats playerStats;

    public override void Interact() //when health kit interacted with
    {
        base.Interact(); // calls base Interact method from Interactables (destroys the 3d game object for the interactable)
        PickUp(); //calls PickUp method
    }

    void PickUp()
    {
        item.Use(); //calls use method from item class on the item object created on line 9
        //This means that whatever type of item has been used it does its use() method (in this project the healthkit applys its health buff)
        Destroy(gameObject); //Destroys the 3d game object after the player has picked it up
    }
}
    
