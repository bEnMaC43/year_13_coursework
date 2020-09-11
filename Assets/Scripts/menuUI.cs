//This script is the parent class for all menu screens in the game
//It provides the methods required to start the game and also quit the game entirely

using UnityEngine;
using UnityEngine.SceneManagement;

public class menuUI : MonoBehaviour
{
    //Methods
    
    //This method is for when the play game button is clicked
    public virtual void PlayGame()
    {
        SceneManager.LoadScene(1); // Loads the main game
    }
    //This method is for when the quit button is clicked
    public virtual void QuitGame()
    {
        Application.Quit();
        print("Quit");
    }


}
