using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullDistances : MonoBehaviour
{
    public float[] distances = new float[32];
    private Camera cam;

    void Start()
    {
        // Cache Camera component for future use
        cam = GetComponent<Camera>();
        if (cam != null)
        {
            cam.layerCullDistances = distances;
        }
        else
        {
            Debug.LogWarning("No Camera component found on this object.");
        }
    }
}
