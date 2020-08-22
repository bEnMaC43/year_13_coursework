//This script is the parent class for Enemy Stats and Player Stats

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    //Attributes
    public int maxHealth;
    public int currentHealth;

    //Methods
    public void TakeDamage(int damage) //this is the universal method for taking damage for both the enemy skeletons and the player
    {
        currentHealth -= damage; //deducts the current health by the damage being inflicted (indicated by the integer perameter)

        if (currentHealth <= 0)
        {
            Die(); //if the health is less than or equal to zero the die method is called
        }
    }
    //this is virtual since the Die method works diferent for both the player and the enemies but they both still have this method
    public virtual void Die ()// This is a "virtual method" since it is the base class and may be overwritten
    {

    }
}
