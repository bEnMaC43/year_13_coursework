//This script manages the username input screen, where the player enters the name they would like displayed on the leaderboard
//UserNameManager class is a subclass from menuUI
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class UserNameManager : menuUI
{
    public GameObject enterButton;

    public string nameEntered; //creates an empty string variable "nameEntered" that will be assigned the value of the name the user enters
    public GameObject inputField; // creates an empty unity GameObject variable that will be assigned to the inputFeild game object where the player types their username
    Regex userNameRequirements = new Regex("^([a-zA-Z]{1,3})$");
    
    //Start() is always called before first frame update
    void Start()
    {
        enterButton = GameObject.FindGameObjectWithTag("EnterButton"); //assigns the empty unity game object to the Enter button from the username entering screen
        inputField = GameObject.FindGameObjectWithTag("UsernameInputField"); //assigns inputFeild to the inputFeild game object that appears on screen
    }

    //executes every frame
    private void Update()
    {
        nameEntered = inputField.GetComponent<Text>().text; //assigns nameEntered to the value of the text entered to the input feild by the user (their user name)
        MatchCollection matches = userNameRequirements.Matches(nameEntered);//returns whether there is a match for the regex in the username the user entered
        if (matches.Count == 1) //if the username entered inside the input field matches the regex
        {
            enterButton.SetActive(true); //the button is activated
        }
        else
        {
            enterButton.SetActive(false); //disables the enter button
        }
    }

    //inherits the virtua PlayGame() method from menuUI
    //Called when the player hits enter after entering a name
    public override void PlayGame()
    {
        PlayerPrefs.SetString("userName", nameEntered);// assigns the name entered to a playerpref called userName (playerPrefs act as variables that can be accessed throughout all the scenes in the game
        SceneManager.LoadScene(1); //loads the main game scene
        

    }
}
