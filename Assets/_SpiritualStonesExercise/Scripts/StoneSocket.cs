using System;
using UnityEngine;


    public class StoneSocket : MonoBehaviour
    {
        [Tooltip("Drag one of the three spiritual stones in here")] //This allows us to display some text when hovering over the variable name in the editor.
        [SerializeField] private GameObject stoneReference;


        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"{other.gameObject.name} gameobject entered the trigger");
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log($"{other.gameObject.name} gameobject exited the trigger");
        }
}


