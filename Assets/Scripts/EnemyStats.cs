using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random; //takes the random class from unity engine namespace and assigns it the name Random

//This scipt manages the stats of enemies

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    GameObject respawner;
    Transform spawnPoint;
    Animator anim;
    public double liveTime;
    double nextSpawnTime = 10;
    public GameObject majorHealthKit; //a game object variable that will be assigned the value of the major health kit 
    int dropChance; //this value will stores a random number that will determine whether the recently killed enemy will drop a health kit
    Vector3 deathLocation; //this vector 3 variable will store the vector 3 position of the enemy skeleton when it dies

    // Start is called before the first frame update
    void Start()
    {
        //majorHealthKit = GameObject.FindGameObjectWithTag("MajorHealthKit");
        respawner = GameObject.FindGameObjectWithTag("Spawner");
        anim = GetComponent<Animator>();
        spawnPoint = GetComponent<Transform>();
        currentHealth = maxHealth;
        print($"Enemy skeleton current health is {currentHealth}");
    }

    /*private void Update()
    {
        liveTime = Math.Round(Time.time);
        if (liveTime == nextSpawnTime)
        {
            respawner.GetComponent<Spawner>().SpawnEnemySkeleton(anim);
            nextSpawnTime += nextSpawnTime + 10;x
        }
    }*/

    void Respawn()
    {
        respawner.GetComponent<Spawner>().SpawnEnemySkeleton(anim);

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //Play hurt animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
       
        //removes enemy from the game
        Destroy(gameObject);
        //disable enemy
        this.enabled = false; //disables script
        GetComponent<CapsuleCollider>().enabled = false; //disables colllisions for the enemy
        //spawn in enemy drops
        dropChance = Random.Range(0, 2);
        print($"dropchance is{dropChance}");
        if (dropChance == 1)
        {
            deathLocation = GetComponent<Transform>().position;
            spawnHealhKit(deathLocation);
        }



        //spawn new enemy
        Respawn();
    }
    //this method should spawn a health kit at the specifed location
    void spawnHealhKit(Vector3 location)
    {
        // increases the y value of the location by one to ensure that the health kits's model is above ground
        location += new Vector3(0, 1, 0);
        Quaternion spawnRotation = Quaternion.LookRotation(new Vector3(0f, 0f, 0f)); //sets the health kit objects rotation to 0,0,0 to prevent it moving with the next enemy skeleton 
        Instantiate(majorHealthKit, location,spawnRotation); //creates a majorHealthKit object , at the location specified in the parameter
    }
}
