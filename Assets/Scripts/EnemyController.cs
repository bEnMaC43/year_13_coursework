//What is a Nav Mesh Agent?

//NavMeshAgent components help you to create characters which avoid each other while moving towards their goal. 
//Agents reason about the game world using the NavMesh
//and they know how to avoid each other as well as other moving obstacles.Pathfinding and 
//spatial reasoning are handled using the scripting API of the NavMesh

//This script controls the enemy AI which governs their movement
//It also enables enemies to attack the player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//This script controls the enemy movement and combat


public class EnemyController : MonoBehaviour

{
    public float lookRadius = 10f; //sets the look radius attribute of the enemy to float 10
    public Animator anim;

    Transform target;
    NavMeshAgent agent;
    GameObject playerCharacter;
    float attackRate = 1f;
    float nextAttackTime = 0f;

    // called at the start
    void Start()
    {
        {
            
            playerCharacter = GameObject.FindGameObjectWithTag("Player"); //seaarches all the objects in the game untill it finds the player (tells that its the player by the tag assigned by the user in the unity editor)
            target = playerCharacter.transform; // stores the position (using the transform data type) of the player object in the target atribute 
            agent = GetComponent<NavMeshAgent>(); //assigns agent atribute of NavMeshAgent data type to the NavMeshAgent component of the object this script is assigned to (the enemy skeleton)
        }
    }
    // called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
        float distance = Vector3.Distance(target.position, transform.position); //uses Distance method to calculate distance between enemy and player
        
        if ( distance > agent.stoppingDistance)
        {
            agent.SetDestination(target.position);//uses NavMeshAgent to force the enemy to follow the player
        }

        //stoppingDistance is the distance where the enemy stops moving towards its target (the player)
        //is set in the unity editor
        if (distance <= agent.stoppingDistance)
        {
            agent.SetDestination(target.position);
            //Face and attack target
            FaceTarget();
            //attack player
            if (Time.time >= nextAttackTime) //if the current time is less than or equal to the next attack time 
            {
                anim.SetTrigger("Attack"); //activates Trigger perameter in animator component which triggers attack animation
                nextAttackTime = Time.time + 1f / attackRate; // delays next attack time by one second so that animation isnt interupted
                playerCharacter.GetComponent<PlayerStats>().TakeDamage(5); //calls takeDamage function from CharacterStats script for the player character with a parameter of 5 (attack inflicts 5 dps)
                //damage is taken at the start of animation, need to find a way to take damage at the end
            }
        } 
        
        

    }


    void FaceTarget() // Once the character has stopped this methods ensures the enemy continues to face its target (the player)
    {
        //The following stores the direction of the target to the enemy
        //It does this by finding the difference between the vector positions of the target(player) and the enemy
        //It then normalizes the result
        Vector3 direction = (target.position - transform.position).normalized;
        //this direction is then stored as a quaternion data type (stores the orinentation of objects in unity)
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        //Look Rotation only stores the x and z values of direction to prevent the enemy's model turning to look up (must stay flat on y axis, since game has no verticality)
        transform.rotation = lookRotation;

    }
}