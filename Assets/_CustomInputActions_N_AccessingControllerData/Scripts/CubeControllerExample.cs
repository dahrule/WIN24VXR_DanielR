using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeControllerExample: MonoBehaviour
{
    [SerializeField] InputActionReference toggle=null;
    [SerializeField] InputActionReference colorChange;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        toggle.action.started += ToggleObject;
    }

    private void Update()
    {
        float value = colorChange.action.ReadValue<float>();
        UpdateColor(value);
    }

    private void OnDestroy()
    {
        toggle.action.started -= ToggleObject;
    }


    private void UpdateColor(float value)
    {
        meshRenderer.material.color = new(value, value, value);
    }

    private void ToggleObject(InputAction.CallbackContext context)
    {
        bool isActive = !(gameObject.activeSelf);
        gameObject.SetActive(isActive);
    }
}
