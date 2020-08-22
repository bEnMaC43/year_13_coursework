using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script is the parent class Item that allows for item objects to be creates

[CreateAssetMenu(fileName = "New Item",menuName = "Inventory/Item")] // Allows for us to create item objects inside of unity, under the inventory tab
//Scriptable objects are blueprints, not applied to game objects like MonoBehavour's(rest of scripts)
public class Item : ScriptableObject //Inherits from ScriptableObject (built in unity class), this also allows for Item objects to be created in unity editor (like a text object or a 3d spehere)
{
    new public string name = "Item"; //Sets the name of this type of object to "Item"
    public Sprite icon = null; //allows designer to input nessecary icon in the unity editor for item being created (eg: weapon ammo or health kit)
    
    //This method should be called when an item has been used by the playerd 
    public virtual void Use ()// This is a "virtual method" since it is the base class and may be overwritten
    {

    }


}
