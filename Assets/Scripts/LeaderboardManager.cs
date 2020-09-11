//This script handles how the leaderboard is accesssed and updated and also how it is displayed to the user at the leaderboard scene (scene 3)
//It inherits from DeathScreen and therfore also inherits from DeathScreen's parent class MenuUI

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class LeaderboardManager : DeathScreen //inherits from DeathScreen so that it can reuse the backToMenu() method
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
        SubmitToLeaderBoard();

        //The purpose of this section is to display the contents of the leaderboard on the screen 
        //TextToList method called
        List<string> fileLines = TextToList(leaderboardTextFile);
        //This takes each line of the leaderboard text file and assigns it the text gameobject that appears on screen in the unity editor
        //float textHeight = 235; //The y variable of the first line of text in the unity editor
        float heightDecrease = 40; //this variable stores the distance between the first line and the next one
        fileLines = sortLeaderboard(fileLines);//returns the sorted string list of the leaderboard
        foreach (string line in fileLines) //goes through the leaderboard line by line showing the results on screen
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

    //when called this method will write to a text file
    public void WriteToTextFile(string newEntry, string textFile)
    {
        print("writing...");
        // creates a streamwritter object from streamwritter class from System.IO
        StreamWriter sw = new StreamWriter(textFile, true); //peramters contain the bool value for weather it should append or not
        sw.WriteLine(newEntry); //writes the newEntry string parameter to the text file
        sw.Close(); //file is closed
    }

    //The purpose of this method is to submit the player's time to the leaderboard
    public void SubmitToLeaderBoard()
    {
        string finalTime = PlayerPrefs.GetString("finalTime"); //takes the final time on the timer when the player died (see OnScreenTimer.cs to see the origin of this values)
        string userName = PlayerPrefs.GetString("userName"); //assigns the userName the player entered to string variable userName
        string submision = $"{finalTime} {userName}";
        WriteToTextFile(submision, leaderboardTextFile); //writes it to the leaderboard text file (which is displayed at leaderboard screen)

    }

    //This method uses a bubble sort algorythm to sort the leaderboard
    public List<string> sortLeaderboard(List<string> Array) //it takes the unsorted list of all the times from the leaderboard text file
    {
        string temp;

        // This foor loop is executed for every item in the array, with x inceasing by 1 each time
        // Once all these foor loops have been executed the bubble sort is complete
        for (int x = 0; x < Array.Count - 1; x++) 
        {
            // Then for each of those loop, another for loop is executed where each time an item in the array is compared with the one next to it
            //Once all these foor loop's have been executed there has been one pass of the bubble sort
            for (int i = 0; i < Array.Count - (1 + x); i++)
            {
                //the first two items (line 1 and line 1 of the text file) of the array are compared
                if (string.Compare(Array[i], Array[i + 1]) == -1) //c# string.Compare method returns -1 if the strings are not in the correct order (largest time first) 
                {
                    //with the use of the string value temp, the two items in the array switch places
                    temp = Array[i];
                    Array[i] = Array[i + 1];
                    Array[i + 1] = temp;
                }
            }
        }
        return Array; //the sorted array is returned

    }
}