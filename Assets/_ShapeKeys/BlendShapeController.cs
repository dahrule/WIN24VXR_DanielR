using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlendShapeController : MonoBehaviour
{
    [SerializeField] float blendSpeed =2f; // Adjust the speed as needed
    [SerializeField] SkinnedMeshRenderer meshRenderer;
    private float blendValue = 0f;

    void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        // Gradually increase the blend shape value using Mathf.Lerp
        blendValue = Mathf.Lerp(blendValue, 1f, blendSpeed * Time.deltaTime);

        // Set the blend shape weight
        meshRenderer.SetBlendShapeWeight(0, blendValue * 100); // Assuming the range is 0 to 100
    }
}

