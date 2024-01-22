using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;
using TMPro;

/// <summary>
/// This runs a countup timer that never stops
/// </summary>
public class ChangingValuesUpdate : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countText;
    private int count;
    private float time;

    void Update()
    {
        RunTimer(1f);
    }

    private void RunTimer(float countTime )
    {
        time += Time.deltaTime;
        if(time>=countTime)
        {
            count++;
            countText.text=count.ToString();
            time = 0;
        }
    }
}
