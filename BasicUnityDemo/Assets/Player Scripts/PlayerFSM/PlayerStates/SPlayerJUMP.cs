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
        //Apply jump force 


        base.Enter();
    }

    
    public override void Update()
    {


        //Continue to allow air movment
        

        //Check for player touching ground


        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }


}
