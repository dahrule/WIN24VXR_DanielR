using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : BaseState
{

    public override void Enter(StateManager stateManager)
    {
        Debug.Log("Enter AlertState");

        //Change cube color
        stateManager.MeshRenderer.material.color = stateManager.alertColor;
    }
    public override void Tick(StateManager stateManager)
    {
        Debug.Log("I am in Alert State");
        
        float distanceToPlayer = stateManager.ProjectedDistanceToPlayer();

        // Flee State Transition
        if (distanceToPlayer <= stateManager.fleeRadiusThreshold)
        {
            stateManager.SwitchState(stateManager.fleeState);
        }
        // Idle State Transition
        else if (distanceToPlayer > stateManager.alertRadiusThreshold)
        {
            stateManager.SwitchState(stateManager.idleState);
        }
    }
    public override void OnCollisionEnter(StateManager stateManager)
    {
        throw new System.NotImplementedException();
    }

}
