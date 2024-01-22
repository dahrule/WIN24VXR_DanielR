using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SuperSlime spawns two Slime enemies when destroyed.
/// </summary>
public class SuperSlime : Slime
{
   [SerializeField] BaseEnemy enemySpawnPrefab;

    public override void Destroy()
    {
        //DisableColliderPhysics();
        SpawnChildren();
    }
    void SpawnChildren()
    {
        if (enemySpawnPrefab == null) return;

        var position = transform.position;
        Instantiate(enemySpawnPrefab, position + Vector3.right, Quaternion.identity);
        Instantiate(enemySpawnPrefab, position + Vector3.left, Quaternion.identity);
    }
    

}
