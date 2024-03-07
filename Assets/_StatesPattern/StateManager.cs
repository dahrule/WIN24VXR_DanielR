using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StateManager: MonoBehaviour
{
    [Header("Idle Behaviour Parameters")]
    [SerializeField] public Color idleColor = Color.blue;
    
    [Header("Alert Behaviour Parameters")]
    [SerializeField] public Color alertColor = Color.yellow;
    [SerializeField] public float alertRadiusThreshold = 6f;

    [Header("Flee Behaviour Parameters")]
    [SerializeField] public float fleeRadiusThreshold = 2f;
    [SerializeField] public Color fleeColor = Color.red;

    [Header("")]
    [SerializeField] public Transform player;

    private BaseState currentState;

    //Properties
    public MeshRenderer MeshRenderer { get; private set; }

    //Create instances for all possible states in my States Machine
    public IdleState idleState=new IdleState();
    public AlertState alertState = new AlertState();
    public FleeState fleeState = new FleeState();

    private void Awake()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        currentState = idleState;
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
       //Draw alert and flee zones
       Gizmos.color = alertColor;
       Gizmos.DrawWireSphere(transform.position, alertRadiusThreshold);

       Gizmos.color = fleeColor;
       Gizmos.DrawWireSphere(transform.position, fleeRadiusThreshold);

        //Draw Line from player to this gameobject
       Gizmos.color = Color.green;
       Gizmos.DrawLine(FlattenPosition(transform.position), FlattenPosition(player.position));
    }

    public float ProjectedDistanceToPlayer()
    {
        Vector3 playerPosFlat = FlattenPosition(player.position);
        Vector3 cubePosFlat = FlattenPosition(transform.position);

        float flatDistanceToPlayer = Vector3.Distance(playerPosFlat, cubePosFlat);

        return flatDistanceToPlayer;
    }

    private Vector3 FlattenPosition(Vector3 position)
    {
        Vector3 planeNormal = Vector3.up;
        return Vector3.ProjectOnPlane(position, planeNormal);
    }

}
