//This scipt manages the stats of enemies

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random; //takes the random class from unity engine namespace and assigns it the name Random

public class EnemyStats : CharacterStats //The EnemyStats class is a subcalass of CharacterStats, which it inherits from
{
    
    GameObject respawner; //this will be assigned to the value of the invisible game object where enemies are spawned in
    Animator anim; //this will be assigned the animator component for the game object this script is assigned to (the enemy skeleton)
    public GameObject majorHealthKit; //a game object variable that will be assigned the value of the major health kit game object that i previosuly created
    int dropChance; //this value will stores a random number that will determine whether the recently killed enemy will drop a health kit
    Vector3 deathLocation; //this vector 3 variable will store the vector 3 position of the enemy skeleton when it dies
    float startTime;
    float timeJump = 10f;
    int currentTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        majorHealthKit = GameObject.FindGameObjectWithTag("MajorHealthKit"); //searches all the gameobjects in the unity project untill it finds the one assigned the "MajorHealthKit" tag and then assigns that to this gameobject variable
        respawner = GameObject.FindGameObjectWithTag("Spawner"); // searches all the gameobjects in the unity project untill it finds the one assigned the "Spawner" tag and then assigns that to this gameobject variable
        anim = GetComponent<Animator>(); //assigned the value of the animator component of the game object this script is assigned to (the enemy Skeleton)

        maxHealth = 100; //sets the maxHealth of the enemy to 100
        currentHealth = maxHealth; //sets the starting health of the enemy to the maxhealth
    }
    //Called every frame
    void Update() 
    {
        currentTime = System.Convert.ToInt32(Time.time);
        print (Time.time);
        print(startTime + timeJump);

        if (Time.time == startTime + timeJump) 
        {
            timeJump += 10; //increases time untill another one spawns
            Respawn();
        
        }
    }

    //When called this method will spawn in another enemy skeleton
    void Respawn()
    {
        respawner.GetComponent<Spawner>().SpawnEnemySkeleton(anim); //calls the SpawnEnemySkeleton method with the anim atribute as a parameter , from the Spawner script (which is assigned to the respawner gameobject)

    }

    //this method is called when the enemy reaches 0 health or less
    public override void Die()
    {
        base.Die();//calls use function from base classs (CharacterStats)

        //removes enemy from the game
        Destroy(gameObject);
        //disable enemy's scripting
        this.enabled = false; //disables script
        GetComponent<CapsuleCollider>().enabled = false; //disables colllisions for the enemy
        //spawn in enemy drops
        dropChance = Random.Range(0, 2); //random number of either 0 or 1
        print($"dropchance is {dropChance}"); //tells programmer wether a health kit should've dropped (can be removed)
        if (dropChance == 1) //if dropChance = 1 health kit is spawned, if 0 it is not
        {
            deathLocation = GetComponent<Transform>().position; // gets the vector3 position of the enemy when it died
            SpawnHealhKit(deathLocation); //calls the spawnHealthKit method with the deathLocation as a parameter
        }
        //spawn new enemy
        Respawn();
    }
    //this method should spawn a health kit at the specifed location
    void SpawnHealhKit(Vector3 location)
    {
        // increases the y value of the location by one to ensure that the health kits's model is above ground
        location += new Vector3(0, 1, 0);
        Quaternion spawnRotation = Quaternion.LookRotation(new Vector3(0f, 0f, 0f)); //sets the health kit objects rotation to 0,0,0 to prevent it moving with the next enemy skeleton 
        Instantiate(majorHealthKit, location,spawnRotation); //creates a majorHealthKit object , at the location specified in the parameter
    }
}
