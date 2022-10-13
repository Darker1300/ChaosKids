
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTester : MonoBehaviour
{
    public float TotalRotation;
    public bool rotating;
    public bool TriggerRotation;
    public float RotationAmount;
    public int Rotations;
    public float Dur;
    public Vector2 start = new Vector2(1,0);
    public Vector2 end = new Vector2(0,1);
    public Vector2 CustomEnd = new Vector2(0,-1);
    public bool forward;
    public bool endForward;
    public int RotationsEnd;
    public AnimationCurve upCurve;
    public AnimationCurve downCurve;
    public bool loop;

    public float Dur2;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotateEver5seconds());
    }

    // Update is called once per frame
    void Update()
    {
        //var firstRotate = Rotate(Dur, start, end);
        // var firstRotate = RotateBack(Dur, start, end,CustomEnd);
        //var firstRotate = RotateAmount(Dur, start, Rotations);
        //if (TriggerRotation)
        //{
        //    StopAllCoroutines();

        //    //StartCoroutine(RotatePlatform(RotationAmount));
        //    StartCoroutine(firstRotate);

        //    TriggerRotation = false;
        //}


    }

    IEnumerator RotateEver5seconds()
    {
        var firstRotate = RotateBack(Dur, start, end, CustomEnd);
        while (true)
        {
            yield return new WaitForSeconds(0.20f);
            yield return StartCoroutine(RotateBack(Dur, start, end, CustomEnd));
            

        }


    }
    private IEnumerator RotatePlatform(float dir)
    {
         
        Vector3 target = new Vector3(0, 0, (transform.eulerAngles.z + dir + 360) % 360);
        
        while (Mathf.Abs(transform.eulerAngles.z - target.z) >= Mathf.Abs(dir * Time.deltaTime * 2))
        {
            //TotalRotation -= dir * Time.deltaTime; 
            transform.Rotate((transform.rotation * new Vector3(0, 0, dir) )* Time.deltaTime);
            
            yield return null;
        }
        TotalRotation -= dir;
        transform.eulerAngles = target;
        rotating = false;
    }

    IEnumerator Rotate(float duration,Vector2 start,Vector2 end)
    {
        float startRotation = Mathf.Atan2(-start.x, start.y) * Mathf.Rad2Deg;
        float endRotationDirection = Mathf.Atan2(-end.x, end.y) * Mathf.Rad2Deg;

        float angle = ((forward) ? (startRotation - endRotationDirection)+ 360 : startRotation - endRotationDirection);

        float endRotation = (startRotation + ((forward) ? Rotations : -Rotations ) * 360f) +angle;
        float t = 0.0f;

        while (t < duration )
        {
            t += Time.deltaTime;
            float zRotation = Mathf.Lerp(startRotation, endRotation, upCurve.Evaluate( t / duration)) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y, zRotation);
            
            yield return null;
        }

        Debug.Log("theTIme" + t +"angle" + angle);
       
    }

    IEnumerator RotateBack(float duration, Vector2 start, Vector2 end ,Vector2 endback)
    {
        float startRotation = Mathf.Atan2(-start.x, start.y) * Mathf.Rad2Deg;
        float endRotationDirection = Mathf.Atan2(-end.x, end.y) * Mathf.Rad2Deg;

        float angle = ((forward) ? (startRotation - endRotationDirection) + 360 : startRotation - endRotationDirection);

        float endRotation = (startRotation + ((forward) ? Rotations : -Rotations) * 360f) + angle;
        float t = 0.0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float zRotation = Mathf.Lerp(startRotation, endRotation,downCurve.Evaluate( t / duration)) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotation);


            Debug.Log("theTIme" + t + "angle" + angle);
            yield return null;
        }

       //forward = !forward;

        t = 0.0f;

        yield return new WaitForSeconds(0.05f);
        startRotation = endRotation;

        //endRotation = (startRotation + ((forward) ? Rotations : -Rotations) * 360f);
        //endRotationDirection = Mathf.Atan2(end.x, end.y) * Mathf.Rad2Deg;
        //////////////////////////
        ///
        endRotationDirection = (Mathf.Atan2(endback.x, endback.y) * Mathf.Rad2Deg);

        endRotation += (forward)? endRotationDirection  + -(RotationsEnd * 360f) : endRotationDirection + (RotationsEnd * 360f);
        Debug.Log("endrot" + endRotation + "start" + startRotation);
        ////////////////////////////////////

        //angle = ((forward) ? (startRotation - endRotationDirection) + 360 : startRotation - endRotationDirection);
        //endRotation = startRotation + angle;
        //angle = ((forward) ? (startRotation - endRotationDirection) + 360 : startRotation - endRotationDirection);



        //endRotation = (startRotation + ((forward) ? Rotations : -Rotations) * 360f) + angle;
        duration = 2.5f;
        while (t < duration)
        {
            t += Time.deltaTime;
            //Debug.Log("Zval" + zRotation);

           float zRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f; 

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotation);

            yield return null;
        }

        //Debug.Log("theTIme" + t + "angle" + angle);

        
        //StartCoroutine(RotateBack(angle));

    }

    IEnumerator RotateAmount(float duration,Vector2 DirectionStart, int thisRotationAmount)
    {
        
        float startRotationZ = Mathf.Atan2(-DirectionStart.x, DirectionStart.y) * Mathf.Rad2Deg;
        //endRotationDirectionZ = Mathf.Atan2(-EndVector.normalized.x, -EndVector.normalized.y) * Mathf.Rad2Deg;

        

        float endRotation = (startRotationZ + ((forward) ? thisRotationAmount : -thisRotationAmount) * 360f) ;
       float t = 0.0f;
        


        while (t < duration)
        {
            t += Time.deltaTime;
            //Debug.Log("Zval" + zRotation);

            float zRotation = Mathf.Lerp(startRotationZ, endRotation, t / duration) % 360.0f;

            transform.localRotation = Quaternion.AngleAxis(zRotation, Vector3.forward);

            yield return null;
        }


    }

        //extract from coroutine 

        public void RotateStartFinishAtPos()
    { 
        
    
    }
    public void RotateSetUp()
    { 
    
    
    }
    public void Trigger()
    {
        var firstRotate = RotateAmount(Dur, start, Rotations);
        if (TriggerRotation)
        {
            StopAllCoroutines();

            //StartCoroutine(RotatePlatform(RotationAmount));
            StartCoroutine(firstRotate);

            TriggerRotation = false;
        }

    }
    ///pingpong
    ///reacure
    ///loop
    ///

}
