using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : BaseState
{
    public override void Enter(StateManager stateManager)
    {
        Debug.Log("Enter AlertState");
        //Change cube color
        stateManager.meshrenderer.material.color = stateManager.alertColor;
    }
    public override void Tick(StateManager stateManager)
    {
        Debug.Log("I am in Alert State");

        //STATE TRANSITIONS
        //Check distance between player and cube
        float distanceToPlayer = Vector3.Distance(stateManager.gameObject.transform.position, stateManager.player.position);
        Debug.Log(distanceToPlayer);

        if (distanceToPlayer > stateManager.alertRadiusThreshold)
        {
            //transition to Idle state
            stateManager.SwitchState(stateManager.idlestate);
        }
        
        else if (distanceToPlayer <= stateManager.fleeRadiusThreshold)
        {
            //Go to Alert State
            stateManager.SwitchState(stateManager.fleeState);
        }
        else
        {
            return;
        }

        


    }
    public override void OnCollisionEnter(StateManager stateManager)
    {
        throw new System.NotImplementedException();
    }
}
