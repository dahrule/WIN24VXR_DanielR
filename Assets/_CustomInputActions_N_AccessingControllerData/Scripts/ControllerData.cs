using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerData : MonoBehaviour
{
    [SerializeField] InputActionProperty velocityProperty;
    [SerializeField] InputActionProperty angularVelocityProperty;


    public Vector3 Velocity{ get; private set; }
    public Vector3 AngularVelocity { get; private set; }


    void Update()
    {
        Velocity=velocityProperty.action.ReadValue<Vector3>();
        AngularVelocity= angularVelocityProperty.action.ReadValue<Vector3>();
    }
}
