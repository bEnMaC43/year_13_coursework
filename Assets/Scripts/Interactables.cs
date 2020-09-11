using UnityEngine;
//this script enables interactble game objects

public class Interactables : MonoBehaviour
{
    public bool interactable = false;
    public Material[] material; //creates an empty array called material which can consist of the Material data type
    Renderer rend; //Renderer of an object actually holds the material 

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>(); // sets rend to the renderer component that this sript is assigned to
        rend.enabled = true; // makes the object visible
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        // if (interactable) is the same as if(interactable = true)
        //JoystickButton0 = the A button on xbox controller
        if (interactable && Input.GetKeyDown(KeyCode.JoystickButton0))//if the object is interactable and the player is presses A
        {
            Interact(); //Player interacts with interactable
        }
        if (interactable)
        {
            rend.sharedMaterial = material[1]; //outlines material telling player that "this item can be interacted with"
        }
        else
        {
            rend.sharedMaterial = material[0]; //standard material
        }
    }
    //is called when the interactable is interacted with (virtual so can be overriden by children classes)
    public virtual void Interact()
    {
        Destroy(gameObject);//once interacted cannot be interacted with again so destorys the gameObject for interactable
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")//if the player touches the interactable 
        {
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other) //if the trigger has been left
    {
        if (other.gameObject.tag == "Player")
        {
            interactable = false;
        }
    }
}
