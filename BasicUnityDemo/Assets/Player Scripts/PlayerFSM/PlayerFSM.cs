using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Actual Player Script where FSM is processed and player events / properties are kept. 
/// </summary>
public class PlayerFSM : MonoBehaviour
{
    public Transform playerCamera;
    public Transform orientation; 

    //Stores the state in the state machine
    State currentState;

    //Stores properties the state machine may need 
    PlayerProperties playerProperties;




    private void Awake()
    {

        playerProperties = new PlayerProperties(GetComponent<Rigidbody>(), playerCamera, orientation);


        currentState = new SPlayerBASE(this.gameObject, playerProperties);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    private void Start()
    {
        
    }

    private void Update()
    {
        currentState = currentState.Process();


    }




    private bool cancellingGrounded;

    //Checking for any collisions with ground
    private void OnCollisionStay(Collision other)
    {

        //Exit if object is not static
        if (!other.gameObject.isStatic) return;

        //Iterate through all collisions in a physics update
        for(int i = 0; i < other.contactCount; i++)
        {
            //Set position of contact
            Vector3 normal = other.contacts[i].normal;
            //Check if this is a slope or floor
            if (IsFloor(normal))
            {
                playerProperties.grounded = true;
                cancellingGrounded = false;
                playerProperties.normalVector = normal;
                CancelInvoke(nameof(StopGrounded));
            }
        }

        //Invoke ground/wall cancel, since we can't check normals with CollisionExit
        float delay = 3f;
        if (!cancellingGrounded)
        {
            cancellingGrounded = true;
            Invoke(nameof(StopGrounded), Time.deltaTime * delay);
        }


    }

    

    private void StopGrounded()
    {
        playerProperties.grounded = false;
    }

    private bool IsFloor(Vector3 v)
    {
        float angle = Vector3.Angle(Vector3.up, v);
        return angle < playerProperties.maxSlopeAngle;
    }


}
