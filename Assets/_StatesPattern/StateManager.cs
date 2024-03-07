using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager: MonoBehaviour
{
    [Header("Behaviour States Stuff")]
    [SerializeField] public Color idleColor = Color.blue;
    

    [Header("Idle Behaviour Parameters")]
    [SerializeField] public Color alertColor = Color.yellow;
    [SerializeField] public float alertRadiusThreshold = 6f;

    [Header("Flee Behaviour Parameters")]
    [SerializeField] public float fleeRadiusThreshold = 2f;
    [SerializeField] public Color fleeColor = Color.red;

    [SerializeField] public Transform player;

    BaseState currentState;

   public MeshRenderer meshrenderer;

    //Create instances for all possible states in my StatesMachine
    public IdleState idlestate=new IdleState();
    public AlertState alertstate = new AlertState();
    public FleeState fleeState = new FleeState();

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

    public void SwitchState(BaseState newBaseState)
    {
        currentState=newBaseState;
        newBaseState.Enter(this);
    }

    //Debugging visually in the editor
    private void OnDrawGizmos()
    {
       Gizmos.color = alertColor;
       Gizmos.DrawWireSphere(transform.position, alertRadiusThreshold);

       Gizmos.color = fleeColor;
       Gizmos.DrawWireSphere(transform.position, fleeRadiusThreshold);
    }
}
