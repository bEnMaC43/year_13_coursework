//This script manages the username input screen, where the player enters the name they would like displayed on the leaderboard
//UserNameManager class is a subclass from menuUI
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserNameManager : menuUI
{
    public string nameEntered; //creates an empty string variable "nameEntered" that will be assigned the value of the name the user enters
    public GameObject inputField; // creates an empty unity GameObject variable that will be assigned to the inputFeild game object where the player types their username

    //Start() is always called before first frame update
    void Start()
    {
        inputField = GameObject.FindGameObjectWithTag("UsernameInputField"); //assigns inputFeild to the inputFeild game object that appears on screen
    }
    
    //inherits the virtua PlayGame() method from menuUI
    //Called when the player hits enter after entering a name
    public override void PlayGame()
    {
        nameEntered = inputField.GetComponent<Text>().text; //assigns nameEntered to the value of the text entered to the input feild by the user (their user name)
        PlayerPrefs.SetString("userName", nameEntered);// assigns the name entered to a playerpref called userName (playerPrefs act as variables that can be accessed throughout all the scenes in the game
        SceneManager.LoadScene(1); //loads the main game scene
    }
}
