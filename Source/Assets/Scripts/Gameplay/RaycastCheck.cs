using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;

public class RaycastCheck : MonoBehaviour
{

    private float m_RaycastDistance;
    private Vector2 RayDirection;
    private string m_Name;
    [TagSelector]
    public string CheckForThisLayer;
    public Vector3 HitPosition;
    public bool findGround = false;
    //public Disc indicator;

    public void Awake()
    {
        //indicator = GetComponent<Disc>();
    }
    public void FixedUpdate()
    {
        if (findGround)
        {

        }
    }
    //call this 
    public Vector3  ShootRayCast(float m_RaycastDistance, Vector2 RayDirection, Vector3 position)
    {
        //Cast a ray from camera position to camera forward vector
        //var ray = new Ray2D (position, RayDirection);
        int layerMask = LayerMask.GetMask("PlanetSurface");
        //If ray hits nothing in range of 15 units return   

        RaycastHit2D hit = Physics2D.Raycast( position, RayDirection,100, layerMask);
        //if (!hit) return Vector3.zero;

        //The color of the ray for debug purpose
        Color rayColor = Color.red;
        Debug.DrawRay(position, RayDirection* 100, rayColor);
       
        //Debug.DrawRay(position, RayDirection, rayColor);
        //If the object is not null
        if (hit.collider != null)
        {

            rayColor = Color.green;          //indicator.transform.position = hit.point;
            return hit.point;
            //Change the color of the ray for debug purpose
        }
        else
        {
            //while (hit.collider == null)
            //{
            // hit = Physics2D.Raycast(position, RayDirection, 100, layerMask);

            //}
            return hit.point;
            //Debug.DrawRay(position, RayDirection , rayColor);
            //Change the color of the ray for debug purpose
            rayColor = Color.red;
            //Debug.DrawRay(position, RayDirection * 100, rayColor);

            Debug.Log("failed");
        }
        return Vector3.zero;
        //Draw the ray for debug purpose

        //If the ray hits the floor return true, false otherwise
        ///return hit.collider;



    }

    public void ShootRayCast( Vector2 RayDirection)
    {
        //Cast a ray from camera position to camera forward vector
        //var ray = new Ray2D (position, RayDirection);
       int layerMask = LayerMask.GetMask("Planet");
        //If ray hits nothing in range of 15 units return   

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(-1,0,0), 1000, layerMask);
        //if (!hit) return Vector3.zero;

        //The color of the ray for debug purpose
        Color rayColor = Color.red;
        Debug.DrawRay(transform.position,new Vector3(-1,0,0) * 500, rayColor);
        //transform.TransformDirection
        //Debug.DrawRay(position, RayDirection, rayColor);
        //If the object is not null
        if (hit.collider != null)
        {

            rayColor = Color.green;

           // return hit.point;
            //Change the color of the ray for debug purpose
        }
        else
        {
            //Debug.DrawRay(position, RayDirection , rayColor);
            //Change the color of the ray for debug purpose
            rayColor = Color.red;
            //Debug.DrawRay(position, RayDirection * 100, rayColor);
        }
        //return Vector3.zero;
        //Draw the ray for debug purpose

        //If the ray hits the floor return true, false otherwise
        ///return hit.collider;



    }
    //private void Update()
    //{
    //    ShootRayCast();
    //}
    //private void OnDisable()
    //{
    //    HitPosition = Vector3.zero;
    //}

}
