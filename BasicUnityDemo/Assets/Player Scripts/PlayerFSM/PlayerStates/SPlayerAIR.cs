using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SPlayerAIR : PlayerState
{


    public SPlayerAIR(GameObject _playerObject, PlayerProperties playerProperties)
        : base(_playerObject, playerProperties)
    {

    }



    public override void Enter()
    {
        Debug.Log("entering player in air state");

        //Player has jumped and is no longer on floor
        playerProperties.grounded = false;

        base.Enter();
    }

    public override void Update()
    {

        


        //Check for when player touches the ground 
        if(playerProperties.grounded == true)
        {
            nextState = new SPlayerBASE(playerObject, playerProperties);
            stage = EVENT.EXIT;
        }

        //Continue to allow movement
        playerProperties.Movement();
        playerProperties.Look();





    }

    public override void Exit()
    {
        base.Exit();
    }

    
}
