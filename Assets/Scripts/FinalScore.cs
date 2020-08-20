//This is quite a simple script that just takes the final score from the OnScreenTimer script that was used in the main game scene and displays it in the game over screen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public string finalTime;

    // Start is called before the first frame update
    void Start()
    {
        finalTime = PlayerPrefs.GetString("finalTime");
        GetComponent<TMPro.TextMeshProUGUI>().text = $"You died after lasting: {finalTime}";

    }

    
}
