using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavDrawLine : MonoBehaviour
{
 


    public Transform startPoint;
    public Transform endPoint;
    public int curveResolution = 10;
    public float lineWidth = 0.2f;
    public LayerMask navMeshLayerMask;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }

    private void Update()
    {
        RoadPath();
    }

    private void RoadPath()
    {
        Vector3[] pathPoints = CalculateCurvePoints();

        lineRenderer.positionCount = pathPoints.Length;
        lineRenderer.SetPositions(pathPoints);
    }

    private Vector3[] CalculateCurvePoints()
    {
        Vector3[] pathPoints = new Vector3[curveResolution + 1];
        float t = 0f;

        for (int i = 0; i <= curveResolution; i++)
        {
            t = i / (float)curveResolution;
            Vector3 point = Vector3.Lerp(startPoint.position, endPoint.position, t);

            RaycastHit hit;
            if (Physics.Raycast(point + Vector3.up * 100f, Vector3.down, out hit, Mathf.Infinity, navMeshLayerMask))
            {
                pathPoints[i] = hit.point;
            }
        }

        return pathPoints;
    }

}
