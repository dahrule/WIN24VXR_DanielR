using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(HitTarget))]
[RequireComponent(typeof(Health))]
public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected Transform playerTarget;
    HitTarget hitTarget;
    Health health;

    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected int attackDamage = 10;
    [SerializeField] protected float secondsBetweenAttacks = 3;



    private void Awake()
    {
        if (playerTarget == null)
        {
            playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }

        hitTarget = GetComponent<HitTarget>();
        health = GetComponent<Health>();
    }

    protected virtual void Update()
    {
        Move();
    }

    protected abstract void Move();
    protected abstract void Attack();
    public abstract void Destroy();

    public void DisableColliderGravity()
    {
        this.gameObject.GetComponent<Collider>().enabled = false;
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    public void TakeHit()
    {
        hitTarget.TakeHit();
        health.TakeDamage(attackDamage);
    }

}
