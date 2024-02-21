using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class PuchSphere : MonoBehaviour
{
    public Rigidbody rgbody;
    public Collider collision;
    [SerializeReference] float forceStrength=3;


    void Awake()
    {
        rgbody= GetComponent<Rigidbody>();
        collision= GetComponent<Collider>();
    }


    /*   private void OnCollisionEnter(Collision collision)
       {
           Debug.Log("Hit");
           ControllerData controllerData;
           if (collision.gameObject.TryGetComponent<XRDirectInteractor>(out XRDirectInteractor interactor))
           {
               controllerData = interactor.gameObject.GetComponentInParent<ControllerData>();
               if (controllerData != null)
               {
                   Vector3 avgPoint = Vector3.zero;
                   foreach (ContactPoint contact in collision.contacts)
                   {
                       avgPoint += contact.point;
                   }

                   avgPoint /= collision.contacts.Length;

                   Vector3 dir = (avgPoint - controllerData.gameObject.transform.position).normalized;

                   rgbody.AddForceAtPosition(dir*10f * controllerData.Velocity.magnitude,avgPoint);

               }
           }
       }*/

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        ControllerData controllerData;
        if (other.gameObject.TryGetComponent<XRDirectInteractor>(out XRDirectInteractor interactor))
        {

            controllerData = interactor.gameObject.GetComponentInParent<ControllerData>();
            if (controllerData != null)
            {

                rgbody.AddForce(forceStrength * -controllerData.Velocity,ForceMode.Impulse);

            }
        }
    }
}
