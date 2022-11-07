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






    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }



}
