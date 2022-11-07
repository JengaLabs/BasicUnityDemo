using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for player states 
public class PlayerState : State 
{


    public PlayerProperties playerProperties;

    public PlayerState(GameObject _playerObject, PlayerProperties _playerProperties)
        : base(_playerObject)
    {
        playerProperties = _playerProperties;


    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }

    //Methods player states will need access too. 
    public bool IsFloor(Vector3 v)
    {
        float angle = Vector3.Angle(Vector3.up, v);
        return angle < playerProperties.maxSlopeAngle;
    }


}
