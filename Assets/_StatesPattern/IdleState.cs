using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void Enter(StateManager stateManager)
    {
        Debug.Log("Enter IdleState");
        //Change cube color
        stateManager.meshrenderer.material.color = stateManager.idleColor;
    }

    public override void Tick(StateManager stateManager)
    {
        Debug.Log("I am in Idle State");

        //Check distance between player and cube
        float distanceToPlayer = Vector3.Distance(stateManager.gameObject.transform.position,stateManager.player.position);
        if(distanceToPlayer<=stateManager.alertRadiusThreshold)
        {
            //Go to Alert State
            stateManager.SwitchState(stateManager.alertstate);
        }



    }

    public override void OnCollisionEnter(StateManager stateManager)
    {
        throw new System.NotImplementedException();
    }

    
}
