using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for player states 
public class PlayerState : State 
{

    public GameObject playerObject;
    public PlayerProperties playerProperties;

    public PlayerState(GameObject _playerObject, PlayerProperties _playerProperties)
        : base(_playerObject)
    {
        playerProperties = _playerProperties;
        playerObject = _playerObject;

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

    


}
