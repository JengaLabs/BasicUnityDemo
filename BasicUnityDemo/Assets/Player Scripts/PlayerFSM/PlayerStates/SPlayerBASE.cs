using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SPlayerBASE : PlayerState
{



    public SPlayerBASE(GameObject _playerObject, PlayerProperties playerProperties) 
        : base(_playerObject, playerProperties)
    {
        
    }


    public override void Enter()
    {

        Debug.Log("enter player in base state");
        

        base.Enter();
    }



    public override void Update()
    {



        //Enable movement
        playerProperties.Look();
        
        playerProperties.Movement();


        //Check if the player is touching the ground
        if (playerProperties.grounded != true)
        {
            //Move to in air state
            //nextState = new SPlayerAIR(playerObject, playerProperties);
            //stage = EVENT.EXIT;
        }

        //Check for jump input
        if (Input.GetAxis("Jump") == 1)
        {
            Debug.Log("jump input");
            nextState = new SPlayerJUMP(playerObject, playerProperties);
            stage = EVENT.EXIT;
        }

        


    }

    public override void Exit()
    {
        base.Exit();
    }

    
}
