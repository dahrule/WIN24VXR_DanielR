using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace LightSaber.intermediate
{
    public class Laser : MonoBehaviour
    {
        [SerializeField] private GameObject laserRoot;
        [SerializeField] private AudioClip laserOnSfx;
        [SerializeField] private AudioClip laserOffSfx;
        [SerializeField] private AudioClip laserHumSfx;

        private XRGrabInteractable interactable;
        private AudioSource audioSource;


        private void Awake()
        {
            interactable = GetComponent<XRGrabInteractable>();
        }

        // Start is called before the first frame update
        void Start()
        {
            InitializeLaser();
        }

        private void Update()
        {
            //TODO: remove this from update. may use the selected event instead.
            if (laserRoot.activeSelf && interactable.isSelected == false) //corner case when laser is not released with out deactivating it.
            {
                DeActivateLaser();
            }
        }
        private void InitializeLaser()
        {
            //Disable laserRoot gameobject
            laserRoot.SetActive(false);

            //Add audio Source component and make it a 3D sound
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.spatialBlend = 1;
        }

        public void ActivateLaser()
        {
            laserRoot.SetActive(true);

            PlayLaserSound(laserOnSfx, false);
            PlayLaserSound(laserHumSfx, true);
        }

        public void DeActivateLaser()
        {
            laserRoot.SetActive(false);
            PlayLaserSound(laserOffSfx,false);
        }

        private void PlayLaserSound(AudioClip sound, bool loop)
        {
            if (loop)
            {
                audioSource.clip =sound;
                audioSource.Play(); 
            }
            else
            {
                audioSource.Stop();
                audioSource.PlayOneShot(sound);
            }
            
        }

    }
}
