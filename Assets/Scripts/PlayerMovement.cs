using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script governs everything related to the player's movement
//This script enables to player object to move correctly when there is a joystick input
//This script also gives the player object the correct animation for movement

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed; 
    private Rigidbody rb;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Animator anim;

    private Camera mainCamera;

    //the Start method gets called when this script is first ran
    void Start()
    {
        //assigns rb the Rigidbody component for Dwarf Hero
        rb = GetComponent<Rigidbody>();
        //assigns anim to the Animator component for Dwarf Hero
        anim = GetComponent<Animator>();
        //assigns mainCamera variable to the main camera of the scene 
        //(unity already recognises Camera.main is the main camera)
        mainCamera = Camera.main;
    }
    //The update method gets called every frame
    void Update()
    {
        // gets vertical or horizontal diretion of thumbstick from input manager
        // then stores the values
        float lh = Input.GetAxis("Horizontal");
        float lv = Input.GetAxis("Vertical");

        //stores input values into a vector3
        //allows movement in 3d space
        moveInput = new Vector3(lh, 0f, lv);
        //avoids player moving off the ground and towards the camera, kind of like implementing gravity
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0;

        //Quaternion is a unity data type that holds rotational value, prevents Gimbal lock
        Quaternion cameraRelativeRotation = Quaternion.FromToRotation(Vector3.forward, cameraForward);
        Vector3 lookToward = cameraRelativeRotation * moveInput; //ensures player movement direction is relative to main camera


        if (moveInput.sqrMagnitude > 0) //runs if player is pushing the left stick
        {
            // creates ray from player position to the position thumbstick is pointing
            Ray lookRay = new Ray(transform.position, lookToward);
            //rotates the player object towards the ray just created
            transform.LookAt(lookRay.GetPoint(1));
        }

        // forward vector (in front player) changes based on move speed
        // moveInput.sqrMagnitude ties it to thumbstick itself
        moveVelocity = transform.forward * moveSpeed * moveInput.sqrMagnitude;
        Animating();
    }
    // fixedUpdated gets called at fixed interval (20ms by deafult)
    void FixedUpdate()
    {
        //every 20 ms the rigidbody moves based on moveVelocity variable
        rb.velocity = moveVelocity;
    }
    // this scripts purpose is to change the player objects animation to correspond with its movement
    void Animating()
    {
        //rb.velocity.magnitude
        if (moveInput.sqrMagnitude > 0) //left stick is being pushed
        {
            anim.SetFloat("blendSpeed", 1); // sets the blend speed to 1 when stick pressed, does running animation
        }
        else
        {
            anim.SetFloat("blendSpeed", 0); // blend speed set to 0 when stick not pressed, does idle animation
        } 
    
    
    }

}