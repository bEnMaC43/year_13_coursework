//What is a Nav Mesh Agent?

//NavMeshAgent components help you to create characters which avoid each other while moving towards their goal. 
//Agents reason about the game world using the NavMesh
//and they know how to avoid each other as well as other moving obstacles.Pathfinding and 
//spatial reasoning are handled using the scripting API of the NavMesh

//This script controls the enemy AI which governs their movement
//It also enables enemies to attack the player

using UnityEngine;
using UnityEngine.AI;
//This script controls the enemy movement and combat


public class EnemyController : MonoBehaviour

{
    public float lookRadius = 10f; //assings the public look radius float the value of 10
    public Animator anim; //creates an empty unity animator object
    float attackRate = 1f; //creates a float variable of the value 1, that dictates how often the enemy can attack the player
    float nextAttackTime = 0f;//creates an emepty float variable of value 0
    Transform target; //creates an empty transform unity object (stores rotation and direction)
    NavMeshAgent agent; //creates an empty NavMeshAgent unity object
    GameObject playerCharacter;

    // called before the first frame 
    void Start()
    {
        {
            
            playerCharacter = GameObject.FindGameObjectWithTag("Player"); //seaarches all the objects in the game untill it finds the player (tells that its the player by the tag assigned by the programmer in the unity editor)
            target = playerCharacter.transform; // stores the transform component of the player object in the target atribute 
            agent = GetComponent<NavMeshAgent>(); //assigns agent variable to the NavMeshAgent component of the object this script is assigned to (the enemy skeleton)
        }
    }
    // called once per frame
    void Update()
    {
        anim = GetComponent<Animator>(); //gets the animator component for the enemy skeleton (since its the object that this script is assigned to in the unity editor)
        float distance = Vector3.Distance(target.position, transform.position); //uses Distance method to calculate distance between enemy and player
        
        if ( distance > agent.stoppingDistance) //is executed if the enemy is far away from the player
        {
            agent.SetDestination(target.position);//uses the SetDestination method from the NavMeshAgent unity class, to set the enemies target as the player
        }

        //stoppingDistance is the distance where the enemy stops moving towards its target (the player)
        //is set in the unity editor
        if (distance <= agent.stoppingDistance)
        {
            //Method that ensures the enemy is always looking at the player
            FaceTarget();
            //attack player
            if (Time.time >= nextAttackTime) //if the current time is less than or equal to the next attack time 
            {
                anim.SetTrigger("Attack"); //activates Trigger perameter in animator component in the unity editor which triggers attack animation
                nextAttackTime = Time.time + 1f / attackRate; // delays next attack time by one second so that animation isnt interupted
                playerCharacter.GetComponent<PlayerStats>().TakeDamage(5); //calls takeDamage function from PlayerStats script for the player character with a parameter of 5 (attack inflicts 5 dps)
            }
        } 
    }


    void FaceTarget() // this methods ensures the enemy continues to face its target (the player)
    {
        //The following stores the direction of the target to the enemy
        //It does this by finding the difference between the vector positions of the target(player) and the enemy
        Vector3 direction = (target.position - transform.position);
        //this direction is then stored as a quaternion data type (stores the orinentation of objects in unity)
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z)); //Look Rotation only stores the x and z values of direction to prevent the enemy's model turning to look up (must stay flat on y axis, since game has no verticality)
        transform.rotation = lookRotation; //assigns the lookRotation to the the enemy skeleton's rotation component

    }
}