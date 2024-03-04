using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : BaseState
{
    public override void Enter(StateManager stateManager)
    {
        Debug.Log("Enter AlertState");
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
