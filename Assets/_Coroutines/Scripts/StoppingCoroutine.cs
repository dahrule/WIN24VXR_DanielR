using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoppingCoroutine : MonoBehaviour
{
    [SerializeField] float smoothing = 1f;
    [SerializeField] Transform target;


    void Start()
    {
        StartCoroutine(MyCoroutine(target));
    }

  IEnumerator MyCoroutine(Transform target)
    {
        bool playerReachedTarget = Vector3.Distance(transform.position, target.position)>0.05f;    
        while(!playerReachedTarget)
        {
            transform.position = Vector3.Lerp(transform.position,target.position, smoothing*Time.deltaTime);

            yield return null;
        }

        print("Reached targer");

        yield return new WaitForSeconds(3f);

        print("Routine is now finished");
    }
}
