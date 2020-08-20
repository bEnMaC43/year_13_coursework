//My aim of this is to introduce interfaces into my code starting with an interface for both EnemyStats and Player Stats to inherit
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterStats
{
    //Properties
    int maxHealth { get; set; }
    int currentHealth { get; set; }

    
}
