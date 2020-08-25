using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required to change scenes

//This script manages the start menu, which allows for the player to navigate the game

public class mainMenu : menuUI
{
    //The following method is the override of the inherited PlayGame method, that rather than directing the player straight to the main game it send them to the username entering screen
    public override void PlayGame()
    {
        base.PlayGame();
        SceneManager.LoadScene(4); //Changes the inherited PlayGame method to load the username enter screen rather than the main game
    }

    //this method is called when leaderboard button clicked, it directs the user to the leaderboards
    public void showLeaderboard()
    {
        SceneManager.LoadScene(3); //loads the leaderboard scene
    }

}
