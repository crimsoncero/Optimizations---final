using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelManager : MonoBehaviour
{
    public GameObject barrelPrefab;
    public int barrelCount = 500;
    private List<GameObject> allBarrels = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < barrelCount; i++)
        {
            GameObject barrel = Instantiate(barrelPrefab);
            barrel.transform.position = new Vector3(Random.Range(-50f, 50f), Random.Range(0f, 10f), Random.Range(-50f, 50f));
            barrel.name = "Barrel_" + i;

            barrel.AddComponent<BarrelBehavior>();

            // Add Rigidbody only if it doesn't already exist
            Rigidbody rb = barrel.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = barrel.AddComponent<Rigidbody>();
                rb.mass = Random.Range(0.5f, 5f);
            }

            allBarrels.Add(barrel);
        }
    }

    void Update()
    {
        // Only apply random rotation every 5 frames for efficiency
        if (Time.frameCount % 5 == 0)
        {
            for (int i = 0; i < allBarrels.Count; i++)
            {
                GameObject b = allBarrels[i];
                b.transform.Rotate(Vector3.up * Random.Range(0.1f, 10f));
            }
        }
    }
}
