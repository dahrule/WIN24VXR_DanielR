using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : BaseState
{
    public override void Enter(StateManager stateManager)
    {
        Debug.Log("Flee State");

        //Change cube color
        stateManager.MeshRenderer.material.color = stateManager.fleeColor;
    }

    public override void Tick(StateManager stateManager)
    {
        Debug.Log("I am in Flee State");

        //Alert State Transition
        if (stateManager.ProjectedDistanceToPlayer() > stateManager.fleeRadiusThreshold)
        {
            stateManager.SwitchState(stateManager.alertState);
        }
    }
    public override void OnCollisionEnter(StateManager stateManager)
    {
        throw new System.NotImplementedException();
    }
}
