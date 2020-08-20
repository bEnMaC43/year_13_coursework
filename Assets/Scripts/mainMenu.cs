using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required to change scenes

//This script manages the main menu, allowing for the play and quit buttons to take the user to the correct destination

public class mainMenu : MonoBehaviour
{
    //This method is for when the play game button is clicked
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // Loads the main game scene
    }
    //This method is for when the quit button is clicked
    public void QuitGame()
    {
        Application.Quit();
        print("Quit");
    }

    //this method is called when leaderboaard button clicked
    public void showLeaderboard()
    {
        SceneManager.LoadScene(3); //loads the leaderboard scene
    }

    //called on death screen when menu button clicked
    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
