using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCell : MonoBehaviour
{

    public GameObject objectsInsideCell;
    public GameObject objectsOutsideCell;
    public bool playerStartsInsideCell = false;

    private bool isPlayerInside = false;

    void Start()
    {
        SetObjectsState(playerStartsInsideCell);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isPlayerInside)
        {
            SetObjectsState(true);
            isPlayerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isPlayerInside)
        {
            SetObjectsState(false);
            isPlayerInside = false;
        }
    }

    private void SetObjectsState(bool isInside)
    {
        objectsInsideCell.SetActive(isInside);
        objectsOutsideCell.SetActive(!isInside);
    }
}
