using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullDistances : MonoBehaviour
{
    public float[] distances = new float[5];

    private Camera cam;

    void Start()
    {
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

//scene b element number and content 8 90 9 160 10 320
//scene a element number and content 8 80 9 170 10 360