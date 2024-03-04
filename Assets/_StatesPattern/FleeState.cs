using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : BaseState
{
    public override void Enter(StateManager stateManager)
    {
        Debug.Log("Flee State");
    }

    public override void Tick(StateManager stateManager)
    {
        throw new System.NotImplementedException();
    }
    public override void OnCollisionEnter(StateManager stateManager)
    {
        throw new System.NotImplementedException();
    }
}
