using UnityEngine;
using System.Collections.Generic;

public class Eivel_LineRenderer : MonoBehaviour
{
    private LineRenderer lr;
    private List<Vector3> points = new List<Vector3>();

    [SerializeField] private float pointSpacing = 0.2f; // min distance between points
    [SerializeField] private int maxPoints = 50; // limit to trail length

    private Vector3 lastPoint;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lastPoint = transform.position;
        points.Add(lastPoint);
        lr.positionCount = 1;
        lr.SetPosition(0, lastPoint);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, lastPoint) >= pointSpacing)
        {
            points.Add(transform.position);
            lastPoint = transform.position;

            if (points.Count > maxPoints)
                points.RemoveAt(0);

            lr.positionCount = points.Count;
            lr.SetPositions(points.ToArray());
        }
    }
}
