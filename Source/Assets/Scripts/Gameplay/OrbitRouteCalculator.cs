using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimationLibrary;

public class OrbitRouteCalculator : MonoBehaviour
{
    public float WholeOrbitTime = 14;
    //this decides the angle it takes to get into and out of orbit 
    public float intoOutOfOrbitAngleAmount = 25;
    public float orbitalHeight;
    public float MiddleOrbitTime;
    public float intoOutOrbitTime;
    public Transform planetCenter;
    public float LongestPathMinDragDist;
    
    // 


    //passes in the local start and end vectors 
    public float GetAngleDiff(Vector3 Start, Vector3 end)
    {
        // Debug.Log("TimeAngle " + Vector3.SignedAngle(Start, end, Vector3.forward));
        float angle = Vector3.SignedAngle(Start, end, Vector3.forward);
        
        return angle;
        
    }
    //returns projectile orbit speed
    public float SecondPerAngle(float angle)
    {

        return (WholeOrbitTime / 360f) * angle;

    }

    //normalizes and rotate direction to desired angle and height
    public Vector3 CalculateObitEnterExit(float height)
    {
       
        //which direction (potentially just choose shortest route)

        //get normalized direction to launch (gives current direction to starting point)

        //rotate it by ToOrbit angle and times it by the desired orbital height 
        //

        return Vector3.zero;
    }
    //this is for how long it is in the air once acheived orbit (this handles also the normal orbit nothing else is needed)
    //public void CalculateOrbitTimes()
    //{
    //    intoOutOrbitTime = intoOutOfOrbitAngleAmount * SecondPerAngle();
    //    //MiddleOrbitTime = 
    //    //get angle diference of whole Travel
    //    //minus orbit into and orbit out
    //    //angle * seconds per angle = gives us 

    //}

    //start and end relative to planet center (which is the transform local of projectile) pass in ShootFromPos
    public void CalculateOrbit(Vector3 Start, Vector3 end,ref OrbitData orbitDataStart, ref OrbitData orbitDataEnd,ref float ActualOrbitTime,ref PrecissionStrike projectile)
    {
        Debug.Log("shoe" + end.magnitude);
        //SHORTEST PATH
        if (end.magnitude < LongestPathMinDragDist)
        {
            Debug.Log("PathShort" + end.magnitude);
            float StartEndAngleDif = GetAngleDiff(Start, end);
            //rotates the vector to the right direction
            //If NEGATIVE this with flip the orbit ends 
            if (StartEndAngleDif < 0)
            {
                intoOutOfOrbitAngleAmount = -Mathf.Abs(intoOutOfOrbitAngleAmount);
                projectile.GetComponent<OrbitProjectile>().speed = -25;
            }
            
            else
            { 
                intoOutOfOrbitAngleAmount = Mathf.Abs(intoOutOfOrbitAngleAmount);
                projectile.GetComponent<OrbitProjectile>().speed = 25;
            }

            //TO ORBIT END POSITION
            orbitDataStart.EndVector = Quaternion.AngleAxis(intoOutOfOrbitAngleAmount, Vector3.forward) * Start.normalized;
            //adds our desired distance
            orbitDataStart.EndVector *= orbitalHeight;

            //FROM ORBIT START POS
            //rotates the vector to the right direction
            orbitDataEnd.StartVector =  Quaternion.AngleAxis(-intoOutOfOrbitAngleAmount, Vector3.forward) * end.normalized;
            //adds our desired distance
            orbitDataEnd.StartVector *= orbitalHeight;
            //fROM ORBIT END POSITION
            //orbitDataEnd.EndVector = end.normalized * 10f;
            //CHECKS RAY CAST TO FIND THE SURFACE OF PLANET
            orbitDataEnd.EndVector = planetCenter.InverseTransformPoint( projectile.rayCheck.ShootRayCast(100,( -end.normalized), planetCenter.transform.position + (end.normalized * 200f)));
            //Debug.DrawLine(end.normalized * 60f, (end.normalized * 60f) +( -end.normalized * 50),Color.red);
            
            //orbitDataEnd.EndVector = end.normalized * 10f;

            ////DEAL WITH TIME NOW GHEE and return it
            //return SecondPerAngle(StartEndAngleDif);
            ActualOrbitTime = Mathf.Abs(SecondPerAngle(StartEndAngleDif - (intoOutOfOrbitAngleAmount * 2)));
        }
        //LONGEST PATH
        else
        {
            Debug.Log("PathLongest" + end.magnitude);
            float StartEndAngleDif = GetAngleDiff(Start, end);
            Debug.Log("shoe" + StartEndAngleDif);
            if (StartEndAngleDif < 0)
            {
                StartEndAngleDif = Mathf.Abs(StartEndAngleDif);
                StartEndAngleDif = 360 - StartEndAngleDif;
                Debug.Log("shoe" + StartEndAngleDif);
                intoOutOfOrbitAngleAmount = -Mathf.Abs(intoOutOfOrbitAngleAmount);
                projectile.GetComponent<OrbitProjectile>().speed = 25;
            }
            else
            {
                StartEndAngleDif = 360 - StartEndAngleDif;
                Debug.Log("shoe" + StartEndAngleDif);
                intoOutOfOrbitAngleAmount = Mathf.Abs(intoOutOfOrbitAngleAmount);
                projectile.GetComponent<OrbitProjectile>().speed = -25;
            }
            //adjust for negstive not sure if this should be here but we will see kek
        
           

            //rotates the vector to the right direction
           
            //TO ORBIT END POSITION
            orbitDataStart.EndVector = Quaternion.AngleAxis(-intoOutOfOrbitAngleAmount, Vector3.forward) * Start.normalized;
            //adds our desired distance
            orbitDataStart.EndVector *= orbitalHeight;

            //FROM ORBIT START POS
            //rotates the vector to the right direction
            orbitDataEnd.StartVector = Quaternion.AngleAxis(intoOutOfOrbitAngleAmount, Vector3.forward) * end.normalized;
            //adds our desired distance
            orbitDataEnd.StartVector *= orbitalHeight;
            //fROM ORBIT END POSITION
            orbitDataEnd.EndVector = planetCenter.InverseTransformPoint(projectile.rayCheck.ShootRayCast(100, ( -end.normalized), planetCenter.transform.position + (end.normalized * 200f)));
            //orbitDataEnd.EndVector = end.normalized * 10f;
            //Debug.DrawLine(end.normalized * 60f, (end.normalized * 60f) + (-end.normalized * 50), Color.red);
            ////DEAL WITH TIME NOW GHEE and return it
            //return SecondPerAngle(StartEndAngleDif);
            ActualOrbitTime = Mathf.Abs(SecondPerAngle(StartEndAngleDif - (Mathf.Abs( intoOutOfOrbitAngleAmount) * 2)));


        }



        
        
    }

    //public void ConfigureDirection(bool left)
    //{
    //    if (left)
    //    {
    //        projectile.speed = 25;
    //        // orbitLerp.orbitDatas.EndVector.x = -20f;
    //    }
    //    else
    //    {
            
    //        //orbitLerp.orbitDatas.EndVector.x = 20f;

    //    }



    //}
    ///
}
