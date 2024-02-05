using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


namespace LightSaber.advanced
{
    [RequireComponent(typeof(XRGrabInteractable))]
    [RequireComponent(typeof(AudioSource))]
    public class Laser : MonoBehaviour
    {
        #region Variables
        [SerializeField] private AudioClip laserSwingSfx;

        [Tooltip("angular velocity threshold to play the swing Sfx")]
        [SerializeField] private float angSpeedThreshold = 2f;

        private XRGrabInteractable grabInteractable;
        private AudioSource audioSource;
        private ControllerData controllerData=null;
        #endregion 

        private void Awake()
        {
            grabInteractable = GetComponent<XRGrabInteractable>();
            audioSource = GetComponent<AudioSource>();
            audioSource.spatialBlend = 1;//Make sound 3D

        }
        private void OnEnable()
        {
            grabInteractable.selectEntered.AddListener(GetXRControllerData);
        }
        private void OnDisable()
        {
            grabInteractable.selectEntered.RemoveListener(GetXRControllerData);
        }

        private void GetXRControllerData(SelectEnterEventArgs arg0)
        {
            Transform interactorParent = arg0.interactorObject.transform.parent; //find the parent game object of the interactor
            controllerData = interactorParent.GetComponent< ControllerData>(); //find the ControllerData script in the parent object
        }

        private void Update()
        {
            if (IsLaserSwinging() && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(laserSwingSfx);
            }
        }

        private bool IsLaserSwinging()
        {
            if (controllerData == null) return false;

            float laserAngularSpeed = controllerData.AngularVelocity.magnitude;
            return laserAngularSpeed > angSpeedThreshold;
        }
    }
}
