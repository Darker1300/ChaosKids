using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PathCreation;
using PathCreation.Utility;
using UnityEngine;
using Object = UnityEngine.Object;

public class NavMeshHelper : MonoBehaviour
{
    [SerializeField] private bool drawGizmos = false;
    [SerializeField] private float offset = 0f;
    [SerializeField] private float circleSize = 20f;

    public Path2D planetPath;
    public PolygonCollider2D planetCollider2D = null;
    public Transform planetCenter = null;



    void Awake()
    {
        planetPath ??= planetCollider2D.GetComponent<Path2D>();
        planetPath?.Initialise(planetCollider2D.points);
    }

    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        if (!planetCollider2D || !planetCenter) return;

        if (!drawGizmos) return;
        Gizmos.DrawWireSphere(planetCenter.position, circleSize);



        Vector2 worldOffset = planetCenter.transform.InverseTransformPoint(planetCollider2D.transform.position);

        // Get points
        var points = planetCollider2D.points;
        var offsetPoints = new Vector2[points.Length];
        var worldOffsetPoints = new Vector2[points.Length];
        // Offset Points by normal
        for (int i = 0; i < points.Length; i++)
        {
            Vector2 sourcePoint = points[i];
            Vector2 surfaceNormal = (sourcePoint + worldOffset).normalized;
            Vector2 offsetPoint = sourcePoint + (surfaceNormal * offset);
            offsetPoints[i] = offsetPoint;
            Vector2 worldOffsetPoint = planetCollider2D.transform.TransformPoint(offsetPoint);
            worldOffsetPoints[i] = worldOffsetPoint;

            Gizmos.color = Color.green;
            Gizmos.DrawRay(worldOffsetPoint, surfaceNormal);

            if (i > 0) Gizmos.DrawLine(worldOffsetPoint, worldOffsetPoints[i - 1]);
        }
        Gizmos.DrawLine(worldOffsetPoints.First(), worldOffsetPoints.Last());
        // Draw Lines
    }
}

