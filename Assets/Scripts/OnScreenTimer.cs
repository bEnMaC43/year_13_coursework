//This script manaages the on screen time UI element, that changes every second to show the current time the player has lasted
//The time must be converted from the pre existing "Time.time" float in unity that keeps track of time spent with application open, to a string of format (minutes):(seconds)

using UnityEngine;
using UnityEngine.UI;//Whenever this is in use it allows for scripts to interact with UI objects from the unity editor

public class OnScreenTimer : MonoBehaviour
{
    public string timerText;
    private float startTime;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time; //sets the current time when the game starts to the startTime atribute

    }

    // Update is called once per frame
    void Update()
    {
        float secondsPassed = Time.time - startTime; //Gives the the time that has elapsed since the timer has startetd

        // This purpose of these lines of code is to convert the total seconds past into a (minutes):(seconds) timer format e.g 5:30
        string minutes = ((int)secondsPassed / 60).ToString(); //takes the integer value for timePassed divided by 60 to find the total minutes pased
        string seconds = ((int)secondsPassed % 60).ToString();// the MOD function is used to get the integer value of seconds passed since the last minute for the second half of the timer

        //this uses string interpolation to store the minutes and seconds value along with a colon as a string that is assigned to the Text Component of the unity text object this script is assigned to
        GetComponent<UnityEngine.UI.Text>().text = $"Time {minutes}:{seconds}";
        PlayerPrefs.SetString("finalTime", $"{minutes}:{seconds}");
        //A PlayerPref is a a pre built function in unity that allows for the  programmer to permeneantly save int,float or strings accross the entire project
        //here i have used playerPrefs to store the the time when the player dies  (finalTime) so that it can be displayed at the death menu (which is a different scene to the game in the unity engine)



    }
}
