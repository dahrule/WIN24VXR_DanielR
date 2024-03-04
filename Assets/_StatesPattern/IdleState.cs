using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void Enter(StateManager stateManager)
    {
        Debug.Log("Enter IdleState");
        stateManager.meshrenderer.material.color = stateManager.idleColor;
    }

    public override void Tick(StateManager stateManager)
    {
        Debug.Log("I am in Idle State");

    }

    public override void OnCollisionEnter(StateManager stateManager)
    {
        throw new System.NotImplementedException();
    }
}
