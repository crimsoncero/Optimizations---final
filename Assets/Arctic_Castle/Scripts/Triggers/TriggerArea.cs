using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{

    public GameObject targetArea;
    public bool startAsVisible = false;

    void Start()
    {
        targetArea.SetActive(startAsVisible);
    }

    void OnTriggerEnter(Collider other)
    {
        targetArea.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        targetArea.SetActive(false);
    }
}
