using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void Enter(StateManager stateManager)
    {
        Debug.Log("Enter IdleState");

        //Change cube color
        stateManager.MeshRenderer.material.color = stateManager.idleColor;
    }

    public override void Tick(StateManager stateManager)
    {
        Debug.Log("I am in Idle State");

        //Alert State Transition
        if (stateManager.ProjectedDistanceToPlayer()<=stateManager.alertRadiusThreshold)
        {
            stateManager.SwitchState(stateManager.alertState);
        }
    }

    public override void OnCollisionEnter(StateManager stateManager)
    {
        throw new System.NotImplementedException();
    }

}
