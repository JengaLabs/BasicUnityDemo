using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//State machine base class for other FSMs to follow 
public class State 
{


    //State object is currently in
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };


    protected EVENT stage;
    protected GameObject stateObject;

    //Hold the next state to enter
    protected State nextState;


    //Constructor class of state
    public State(GameObject _stateObject)
    {
        //HOld onto object 
        stateObject = _stateObject;
    }

    //First method to run in state
    public virtual void Enter()
    {
        stage = EVENT.UPDATE;
    }

    //Method that runs state processes
    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    }

    //Final method to run in a state 
    public virtual void Exit()
    {
        stage = EVENT.EXIT;
    }

    //Observe which state process to run next
    public State Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if(stage == EVENT.EXIT)
        {
            //Run any process for exiting the state
            Exit();
            //Return the next created state
            return nextState;
        }
        //Continue to use the current state
        return this;
    }
    
}
