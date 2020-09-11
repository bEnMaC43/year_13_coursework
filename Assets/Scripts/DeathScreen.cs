//This class manages the menu screen that appears when the player has died

using UnityEngine.SceneManagement;
public class DeathScreen : menuUI
{
    
    //called on death screen when menu button clicked
    //returns the player back to the main menu
    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }

    //This script keeps the original PlayGame() method from menuUI and doesn't overide it
    //This means that when you click Restart at the death screen it skips the username entering screen and goes straight to the main game
    //This means that the username entered when you first started the game is kept and doesn't get ovveriden
}
