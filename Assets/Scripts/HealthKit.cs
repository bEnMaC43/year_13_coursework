using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script allows for health kit item's that when activated increase the players health

[CreateAssetMenu(fileName = "New Health Kit",menuName = "Inventory/Kit")]
public class HealthKit : Item //Inherits all the atributes and methods from the Item class 
{

    public int healthModifier;
    PlayerStats playerStats; //creates an instance of playerStats (uses PlayerStats.cs script)

    void Start()
    {
        playerStats = PlayerStats.instance; //assigns playerStats to the current instance of PlayerStats (which is the player)
        //this allows for this script to modify the players stats (as long as public)
    }

    public override void Use() //overides the virtual use method inside of the Item Class
    {
        base.Use();//calls use function from base class
        ApplyEffect();
    }
    public void ApplyEffect()
    {
        PlayerStats.instance.GainHealth(healthModifier); // increases the players health by the healthModifier variable
    }
}
