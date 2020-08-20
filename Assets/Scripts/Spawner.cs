using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This script manages all the methods for spawning game objects in runtime
//at the moment this only consists of support for spawning Enemy Skeletons, but could be expanded if i wanted to 

public class Spawner : MonoBehaviour
{
    public GameObject spawnee; //The object being spawned in
    Transform spawnLocation;//The location that the object will be spawned in at
    

    private void Start()
    {
        spawnLocation = GetComponent<Transform>(); //gets the transform value of the game object that this script is assigned to 
        //transform values store location and orientation
    }

    
    /* DELETE THIS COMMENT BLOCK WHEN FINISHED
    At the moment the following method requires the skeletons animator component to be passed through as a paramter, which introduces no issues for this project
    However this could introduce complications in future projects
    I might decide to make this method work without any paramaters to solve this but it isn't nessecary 
    DELETE THIS COMMENT BLOCK WHEN FINISHED */

    //When called this method creates a new skeleton enemy in the game
    public void  SpawnEnemySkeleton (Animator anim)
    {

        //Finds the enemy skeleton game object via the "Enemy" tag assigned inside the unity editor
        spawnee = GameObject.FindGameObjectWithTag("Enemy");
        //The Instantiate function spawns in the model at the location of the spawner
        spawnee = Instantiate(spawnee, spawnLocation.position, spawnLocation.rotation);
        //All the missing components that the enemy scripts need to run are added to this new object
        spawnee.AddComponent<CapsuleCollider>();
        spawnee.AddComponent<EnemyStats>(); //This creates a new instance of the EnemyStats class for this new enemy skeleton
        spawnee.AddComponent<EnemyController>(); //This creates an instance of the Enemy Controller class for this new enemy skeleton

        //The values for each component that need to be changed from their deafult are changed
        spawnee.GetComponent<CapsuleCollider>().center = new Vector3(0f, 0.7f, 0f);
        spawnee.GetComponent<CapsuleCollider>().radius = 0.3f;
        spawnee.GetComponent<CapsuleCollider>().height = 1.6f;

        spawnee.GetComponent<NavMeshAgent>().speed = 3.5f;
        spawnee.GetComponent<NavMeshAgent>().acceleration = 8;
        spawnee.GetComponent<NavMeshAgent>().stoppingDistance = 1;
        spawnee.GetComponent<NavMeshAgent>().radius = 0.5f;

        RuntimeAnimatorController animController = anim.runtimeAnimatorController;
        spawnee.GetComponent<Animator>().runtimeAnimatorController = animController;

        //All of the components are then enabled
        spawnee.GetComponent<Animator>().enabled = true;
        spawnee.GetComponent<CapsuleCollider>().enabled = true;
        spawnee.GetComponent<NavMeshAgent>().enabled = true;
        spawnee.GetComponent<EnemyStats>().enabled = true;
        spawnee.GetComponent<EnemyController>().enabled = true;




    }

}

