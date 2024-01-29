using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerData : MonoBehaviour
{
    [SerializeField] InputActionProperty velocityProperty;

    public Vector3 Velocity{ get; private set; }


    void Update()
    {
        Velocity=velocityProperty.action.ReadValue<Vector3>();
    }
}
