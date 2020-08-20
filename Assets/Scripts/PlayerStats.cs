
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Allows to return to main menu

//This script controls the players stats
//Could be used for lots of different characters, but in this program is only used for the main player
//Could improve PlayerStats and EnemyStats script wth a CharacterStats interface due to their similar atributes and methods ?

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance; //creates a a PlayerStats variable called instance

    void Awake()
    {
        instance = this; //instance is assigned the value of the the instance of the PlayerStats class for the unity game object (the player game object) that this script is assigned to 
    }
    //this creates an instance of PlayerStats for other scripts to interact with, and assigns it to the current instance (the player)

    //Atributes
    public int maxHealth = 100;
    public int currentHealth { get; private set; } // emsures only this script can change currentHealth, even if others can access

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        print($"Player has {currentHealth} HP");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // is a public method, since it will need to be called by an enemy object
    // the enemy object will tell the player object how much damage it takes through this method
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //decreases character health by damage
        if (currentHealth <= 0) { Death(); } //checks if character has no health left
    }

    public void GainHealth(int healthGained)
    {
        currentHealth += healthGained; //increases playerHealth by healthGained
        if (currentHealth > maxHealth) { currentHealth = maxHealth; } //ensures character cannot exceed max health
        print(currentHealth);
    }
    public void Death()
    {
        SceneManager.LoadScene(2); // Loads the death scene

    }
    
}
