using System;
using UnityEngine;

public class StoneSocket : MonoBehaviour
{
    [SerializeField] private GameObject stoneReference;
    
    private static int stoneCount = 0; //static fields keep the same value for all instances of this class. In our example scene we have 3 StoneSocket instances.
    private static readonly int totalStones = 3;
  
    public static event Action OnAllStonesPlaced;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject!=stoneReference) return;

        stoneCount++;

        if (stoneCount == totalStones)
        {
            OnAllStonesPlaced?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != stoneReference) return;

        stoneCount--;
    }
}

