//This script handles how the leaderboard is accEsssed and updated and also how it is displayed to the user at the leaderboard scene (scene 3)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;


public class LeaderboardManager : MonoBehaviour
{
    //Location of where the text lines will spawn in 3d space (assigned in unity editor)
    public Transform contentWindow;

    //prefrab for actual text  lines that appear on screen in unity editor (created in unity editor and assigned to this GameObject
    public GameObject recallTextObject;

    //string value for the already created leaderboard text file from the assets folder of the unity project
    string leaderboardTextFile = Application.streamingAssetsPath + "/Text Files/" + "Leaderboard" + ".txt"; 

    // Start() acts like main() traditionally would since it is called on the first frame as long as this script is enabled
    void Start()
    {
        string finalTime = PlayerPrefs.GetString("finalTime"); //takes the final time on the timer when the player died (see OnScreenTimer.cs to see the origin of this values)
        WriteToTextFile(finalTime,leaderboardTextFile); //writes it to the leaderboard text file (which is displayed at leaderboard screen)
        
        //The purpose of this section is to display the contents of the leaderboard on the screen 
        //TextToList method called
        List <string> fileLines = TextToList(leaderboardTextFile);
        //This takes each line of the leaderboard text file and assigns it the text gameobject that appears on screen in the unity editor
        //float textHeight = 235; //The y variable of the first line of text in the unity editor
        float heightDecrease = 40; //this variable stores the distance between the first line and the next one
        fileLines.Sort();//Sort() sorts the times into accending order 
        foreach (string line in fileLines.Select(x => x).Reverse()) //sorts through the the list in reverse order (descending) and then writes them to the on screen UI
        {
               
            GameObject newLine = Instantiate(recallTextObject, contentWindow); //the game object for the new line is created with the instantiate method, with its type of game object (text) and the position
            newLine.GetComponent<Text>().text = line; //this actually sets the on screen text to display the string value for this line
            newLine.GetComponent<Transform>().position -= new Vector3(-10f, heightDecrease, 0f); //the height of this new line is then decreased by the set value
            heightDecrease += 40; //This value is increased every time the loop is ran to ensure each line is below the last
            
        }
    }


    
    //When called this method should take a text file saved to string value and returns it as a list where each line is a new element
    static List<string> TextToList(string readFromFilePath)
    {
        //creates a string list called fileLines, reads every line inside the the text file is read using the ReadAllLines() method from System.IO
        //Puts all these lines into a list
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList(); //ToList() uses the system.Linq namespace
        //returns that list
        return fileLines;
    }
    //Is called when the on screen menu buton is clicked, and loads player into the main menu
    public void returnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    //when called this method will write to a text file
    public void WriteToTextFile(string newEntry, string textFile)
    {
        print("writing...");
        // creates a streamwritter object from streamwritter class from System.IO
        StreamWriter sw = new StreamWriter(textFile,true); //peramters contain the bool value for weather it should append or not
        sw.WriteLine(newEntry); //writes the newEntry string parameter to the text file
        sw.Close(); //file is closed
    }

}