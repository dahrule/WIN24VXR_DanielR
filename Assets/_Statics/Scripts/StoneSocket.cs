using System;
using UnityEngine;

public class StoneSocket : MonoBehaviour
{
    [Tooltip("Drag one of the three spiritual stones in here")] //This allows us to display some text when hovering over the variable name in the editor.
    [SerializeField] private GameObject stoneReference;

    //static fields keep the same value for all instances of this class. In our example scene we have 3 StoneSocket instances all sharing these same values.
    private static int stoneCount = 0;
    private static int stonesRequired = 3;

    public static event Action OnAllStonesPlaced;

    private void OnTriggerEnter(Collider other)
    {
        //Add one to stonecout when the right stone is placed.
        if (other.gameObject!=stoneReference) return; 

        stoneCount++;

        //Logic when all the required stones have been placed.
        if (stoneCount == stonesRequired) 
        {
            OnAllStonesPlaced?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Susbtract one to stonecout when the stone is removed.
        if (other.gameObject != stoneReference) return;

        stoneCount--;
    }
}

