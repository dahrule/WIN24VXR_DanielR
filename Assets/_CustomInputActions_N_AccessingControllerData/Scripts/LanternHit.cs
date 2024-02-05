using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class LanternHit : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out XRDirectInteractor interactor))
        {
            Debug.Log("Intercatro found");
            ControllerData controllerData=interactor.gameObject.GetComponentInParent<ControllerData>();
            if(controllerData!=null)
            {
                rb.AddForce(controllerData.Velocity*10, ForceMode.Impulse);
                Debug.Log("GOodfound");

            }
        }

    }
}
