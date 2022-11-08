using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Player jumping action 
public class SPlayerJUMP : PlayerState
{

    public SPlayerJUMP(GameObject _playerObject, PlayerProperties _playerProperties)
        : base(_playerObject, _playerProperties)
    {

    }


    public override void Enter()
    {

        Debug.Log("entering jump state");

        //Apply jump force 
        playerProperties.Jump();

        base.Enter();
    }

    
    public override void Update()
    {
        //set player grounded false 
        playerProperties.grounded = false;

        //move player to in air state 
        nextState = new SPlayerAIR(playerObject, playerProperties);
        stage = EVENT.EXIT;


    }

    public override void Exit()
    {
        base.Exit();
    }



    


}
