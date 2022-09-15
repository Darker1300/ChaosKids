using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetHelper : MonoBehaviour
{
    [SerializeField] private bool drawGizmos = false;
    [SerializeField] private float circleSize = 20f;

    private void OnDrawGizmos()
    {
        if (!drawGizmos) return;
        Gizmos.DrawWireSphere(transform.position, circleSize);
    }


}
