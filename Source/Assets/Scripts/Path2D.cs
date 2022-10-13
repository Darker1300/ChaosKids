using System.Collections;
using System.Collections.Generic;
using PathCreation;
using PathCreation.Utility;
using UnityEngine;

public class Path2D : MonoBehaviour
{
    public Vector2[] localPoints;
    /// Total distance from the first vertex up to each vertex in the polyline
    public float[] lengthAtPoint;
    /// Percentage along the path at each vertex (0 being start of path, and 1 being the end)
    public float[] times;
    /// Total distance between the vertices of the polyline
    public float length;

    public void Initialise(Vector2[] points)
    {
        localPoints = points;
        lengthAtPoint = new float[localPoints.Length];

        Vector2 prevPoint = localPoints[0];
        // initialise first vertex
        lengthAtPoint[0] = 0f;

        // Calc length at each vertex after first
        for (int i = 1; i < localPoints.Length; i++)
        {
            Vector2 curPoint = localPoints[i];
            float curLength = Vector2.Distance(curPoint, prevPoint);
            length += curLength;
            lengthAtPoint[i] = length;

            prevPoint = localPoints[i];
        }

        // Calc times
        times = new float[localPoints.Length];
        times[0] = 0f;
        for (int i = 1; i < localPoints.Length; i++)
            times[i] = lengthAtPoint[i] / length;
    }

    /// Gets point on path based on distance travelled.
    public Vector3 GetPointAtDistance(float dst)
    {
        float t = dst / length;
        return GetPointAtTime(t);
    }

    /// Gets point on path based on 'time' (where 0 is start, and 1 is end of path).
    public Vector3 GetPointAtTime(float t)
    {
        var data = CalculatePercentOnPathData(t);
        return Vector3.Lerp(GetPoint(data.previousIndex), GetPoint(data.nextIndex), data.percentBetweenIndices);
    }

    public Vector3 GetPoint(int index)
    {
        return MathUtility.TransformPoint(localPoints[index], transform, PathSpace.xy);
    }

    /// For a given value 't' between 0 and 1, calculate the indices of the two vertices before and after t. 
    /// Also calculate how far t is between those two vertices as a percentage between 0 and 1.
    TimeOnPathData CalculatePercentOnPathData(float t)
    {
        // Constrain t
        // If t is negative, make it the equivalent value between 0 and 1
        if (t < 0)
        {
            t += Mathf.CeilToInt(Mathf.Abs(t));
        }
        t %= 1;

        int prevIndex = 0;
        int nextIndex = localPoints.Length - 1;
        int i = Mathf.RoundToInt(t * (localPoints.Length - 1)); // starting guess

        // Starts by looking at middle vertex and determines if t lies to the left or to the right of that vertex.
        // Continues dividing in half until closest surrounding vertices have been found.
        while (true)
        {
            // t lies to left
            if (t <= times[i])
            {
                nextIndex = i;
            }
            // t lies to right
            else
            {
                prevIndex = i;
            }
            i = (nextIndex + prevIndex) / 2;

            if (nextIndex - prevIndex <= 1)
            {
                break;
            }
        }

        float abPercent = Mathf.InverseLerp(times[prevIndex], times[nextIndex], t);
        return new TimeOnPathData(prevIndex, nextIndex, abPercent);
    }

    TimeOnPathData CalculateClosestPointOnPathData(Vector3 worldPoint)
    {
        float minSqrDst = float.MaxValue;
        Vector3 closestPoint = Vector3.zero;
        int closestSegmentIndexA = 0;
        int closestSegmentIndexB = 0;

        for (int i = 0; i < localPoints.Length; i++)
        {
            int nextI = i + 1;
            if (nextI >= localPoints.Length)
            {

                nextI %= localPoints.Length;

            }

            Vector3 closestPointOnSegment = MathUtility.ClosestPointOnLineSegment(worldPoint, GetPoint(i), GetPoint(nextI));
            float sqrDst = (worldPoint - closestPointOnSegment).sqrMagnitude;
            if (sqrDst < minSqrDst)
            {
                minSqrDst = sqrDst;
                closestPoint = closestPointOnSegment;
                closestSegmentIndexA = i;
                closestSegmentIndexB = nextI;
            }

        }
        float closestSegmentLength = (GetPoint(closestSegmentIndexA) - GetPoint(closestSegmentIndexB)).magnitude;
        float t = (closestPoint - GetPoint(closestSegmentIndexA)).magnitude / closestSegmentLength;
        return new TimeOnPathData(closestSegmentIndexA, closestSegmentIndexB, t);
    }


    /// Finds the distance along the path that is closest to the given point
    public float GetClosestDistanceAlongPath(Vector3 worldPoint)
    {
        TimeOnPathData data = CalculateClosestPointOnPathData(worldPoint);
        return Mathf.Lerp(lengthAtPoint[data.previousIndex], lengthAtPoint[data.nextIndex], data.percentBetweenIndices);
    }

    public struct TimeOnPathData
    {
        public readonly int previousIndex;
        public readonly int nextIndex;
        public readonly float percentBetweenIndices;

        public TimeOnPathData(int prev, int next, float percentBetweenIndices)
        {
            this.previousIndex = prev;
            this.nextIndex = next;
            this.percentBetweenIndices = percentBetweenIndices;
        }
    }

}
