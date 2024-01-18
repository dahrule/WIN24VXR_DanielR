using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : BaseEnemy
{
    /// <summary>
    /// Slime is an Enemy that only moves towards player and causes minimum damage
    /// </summary>
    protected override void Move()
    {
        // Move our position a step closer to the target.
        var step = moveSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, step);
    }

    protected override void Attack()
    {
        string message = $"{this.name} is attacking player every {secondsBetweenAttacks} seconds";
        Debug.Log(message, this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent<Health>(out Health playerHealth))
        {
            InvokeRepeating("Attack",1f,secondsBetweenAttacks); //TODO: Change to a Couroutine
        }
    }

    public override void Destroy()
    {
        Debug.Log("Destroy");
    }
}
