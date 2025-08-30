using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class BarrelBehavior : MonoBehaviour
{
    private List<Vector3> points = new List<Vector3>(5);
    private System.Text.StringBuilder sb = new System.Text.StringBuilder();

    void Update()
    {
        List<int> randomList = new List<int> { 1, 2, 3, 4, 5 };
        List<int> even = new List<int>();
        foreach (var x in randomList)
        {
            if (x % 2 == 0) even.Add(x);
        }

        sb.Clear();
        sb.Append("Barrel Pos: ");
        sb.Append(transform.position);
        Debug.Log(sb.ToString());

        points.Clear();
        for (int i = 0; i < 5; i++)
        {
            points.Add(UnityEngine.Random.insideUnitSphere);
        }

        transform.localScale = Vector3.one * UnityEngine.Random.Range(0.2f, 0.3f);

        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 10f))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
        }
    }
}
