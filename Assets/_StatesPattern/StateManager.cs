using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager: MonoBehaviour
{
    [Header("Behaviour States Stuff")]
    [SerializeField] public Color idleColor = Color.blue;
    [SerializeField] public Color alertColor= Color.yellow;
    [SerializeField] public Color fleeColor=Color.red;

    BaseState currentState;

   public MeshRenderer meshrenderer;

    //Create instances for all possible states in my StatesMachine
    IdleState idlestate=new IdleState();
    AlertState alertstate = new AlertState();
    FleeState fleeState = new FleeState();

    private void Awake()
    {
        meshrenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        currentState = idlestate;
        currentState.Enter(this);

    }

    void Update()
    {
        currentState.Tick(this);
    }
}
