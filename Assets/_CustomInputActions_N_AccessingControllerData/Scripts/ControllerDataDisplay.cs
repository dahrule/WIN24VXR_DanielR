using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControllerDataDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI RightControllerSpeedText;
    [SerializeField] ControllerData RightControllerData;




    // Update is called once per frame
    void Update()
    {
        float magnitude = RightControllerData.Velocity.magnitude;
        RightControllerSpeedText.text = magnitude.ToString("F1"); // "F1" formats the number to one decimal place
    }

}
