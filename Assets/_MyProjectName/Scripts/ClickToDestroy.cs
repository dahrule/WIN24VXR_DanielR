using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDestroy : MonoBehaviour
{
    [SerializeField] int testDamage = 10;
       void Update()
    {
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {

                    /*if (hit.collider.TryGetComponent(out HitTarget hitTarget))
                    {
                        hitTarget.TakeHit();

                    }

                    if (hit.collider.TryGetComponent(out Health health))
                    {
                        health.TakeDamage(testDamage);

                    }*/

                    if (hit.collider.TryGetComponent(out BaseEnemy enemy))
                    {
                        enemy.gameObject.GetComponent<Health>().TakeDamage(testDamage);
                        enemy.gameObject.GetComponent<HitTarget>().TakeHit();


                    }
                }
            }
        }
    }
}
