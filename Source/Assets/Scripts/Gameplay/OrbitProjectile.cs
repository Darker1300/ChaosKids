using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 pivotPoint;
    public Transform objectToOrbit;
    public float speed;
    public void RotateAroundPoint()
    {
        // Rotates around the pivot point and the Y-Axis by 90 degrees
        //transform.RotateAround(pivotPoint, Vector3.up, 90);
        transform.RotateAround(objectToOrbit.position, Vector3.forward, speed * Time.deltaTime);

    }
   void Awake()
    {
        objectToOrbit = GameObject.FindGameObjectWithTag("Planet").transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
