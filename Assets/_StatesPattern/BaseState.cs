using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public abstract void Enter(StateManager stateManager);
    public abstract void Tick(StateManager stateManager);
    public abstract void OnCollisionEnter(StateManager stateManager);

}
