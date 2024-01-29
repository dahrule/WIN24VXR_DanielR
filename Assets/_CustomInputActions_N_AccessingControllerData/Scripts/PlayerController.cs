using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] InputActionReference jump;
    [SerializeField] float jumpForce=500f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        jump.action.performed += OnJump;
    }

    private void OnDisable()
    {
        jump.action.performed -= OnJump;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        //Jump logic goes here.
        if (IsGrounded()) 
        {
            //Add a force to the rigidbody of magnitude 200 in the world Updirection.
            rb.AddForce(jumpForce * Vector3.up);
        }
    }

    bool IsGrounded() 
    {
        //Check if the XRrig is touching ground using a Physics.Raycast
        
        return Physics.Raycast(transform.position, Vector3.down, 2f);
    }

    
}

   
