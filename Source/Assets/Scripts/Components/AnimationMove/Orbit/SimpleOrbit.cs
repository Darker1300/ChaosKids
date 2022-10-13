using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using AnimationLibrary;
namespace AnimationLibrary
{
    [Serializable]
    public class SimpleOrbit
    {
        // Start is called before the first frame update
        //NAME
       // public LerpWithinFactor SequentialLerp;
        public OrbitData orbitDatas;

        // public bool rotAround;
        // Time to move from sunrise to sunset position, in seconds.
        // The time at which the animation started.

        private float overallStartTime;
        public float overallDurationTime;

        public void LerpOrbit(float percentage)
        {
            if (orbitDatas.Active)
            {
                switch (orbitDatas.thisRotationLerpType)
                {
                    case OurLerpType.LERP:

                        //if timed lerp to time value else use percentage

                        orbitDatas.TransformOrbitPos = orbitDatas.Timed ? VectorLerp(orbitDatas.animationCurve.Evaluate(TimeBasedCalculateJourneyTime() * orbitDatas.OrbitMultiplier)) : VectorLerp(orbitDatas.animationCurve.Evaluate(percentage * orbitDatas.OrbitMultiplier));

                        break;

                    case OurLerpType.LERPUNCLAMPED:

                        //if timed lerp to time value else use percentage
                        orbitDatas.TransformOrbitPos = orbitDatas.Timed ? VectorLerpUnClamped(orbitDatas.animationCurve.Evaluate(TimeBasedCalculateJourneyTime() * orbitDatas.OrbitMultiplier)) : VectorLerpUnClamped(orbitDatas.animationCurve.Evaluate(percentage * orbitDatas.OrbitMultiplier));



                        // TransformToRotate.localRotation = Timed ? Quaternion.LookRotation(Vector3.forward, VectorLerpUnClamped(TimeBasedCalculateJourneyTime())) : Quaternion.LookRotation(Vector3.forward, VectorLerpUnClamped(percentage));

                        break;

                    case OurLerpType.SLERP:

                        //if timed lerp to time value else use percentage
                        orbitDatas.TransformOrbitPos = orbitDatas.Timed ? VectorSlerp(orbitDatas.animationCurve.Evaluate(TimeBasedCalculateJourneyTime() * orbitDatas.OrbitMultiplier)) : VectorSlerp(orbitDatas.animationCurve.Evaluate(percentage));

                        //TransformToRotate.localRotation = Timed ? Quaternion.LookRotation(Vector3.forward, VectorSlerp(TimeBasedCalculateJourneyTime())) : Quaternion.LookRotation(Vector3.forward, VectorSlerp(percentage));

                        break;

                    case OurLerpType.SLERPUNCLAMPED:

                        //if timed lerp to time value else use percentage
                        orbitDatas.TransformOrbitPos = orbitDatas.Timed ? VectorSlerpUnClamped(orbitDatas.animationCurve.Evaluate(TimeBasedCalculateJourneyTime() * orbitDatas.OrbitMultiplier)) : VectorSlerpUnClamped(orbitDatas.animationCurve.Evaluate(percentage * orbitDatas.OrbitMultiplier));





                        // TransformToRotate.localRotation = Timed ? Quaternion.LookRotation(Vector3.forward, VectorSlerpUnClamped(TimeBasedCalculateJourneyTime())) : Quaternion.LookRotation(Vector3.forward, VectorSlerpUnClamped(percentage));
                        break;


                }

            }

        }



        public void OrbitSetUp()
        {
            //____________________________________________________________
            ///////////////////////ORBIT////////////////
            // ___________________________________________________________


            orbitDatas.center = (orbitDatas.StartVector + orbitDatas.EndVector) * 0.5f;

            //lets move the center Down which will make the arc verticle we could change this to make it arc a different way
            Debug.Log("orbit center" + orbitDatas.center);
            // orbitDatas[i].center -= new Vector3(1,0, 0);
            //Debug.Log("orbit center" + orbitDatas[i].center);
            //orbitDatas[i].center -= new Vector3(0.5f, 0.5f, 0);
            //orbitDatas[i].center =  i == 0 ? new Vector3(0.5f,0.5f, 0): new Vector3(-0.5f, 0.5f, 0);
            //orbitDatas[i].center -=  i == 0 ? new Vector3(1, 0, 0) : new Vector3(-1, 0, 0);
            // orbitDatas[i].center = orbitDatas[i].center.normalized * 19f;

            //if (i == 0)
            //{
            //    orbitDatas[i].center -= new Vector3(1, 0, 0);
            //}
            //else
            //{
            //    orbitDatas[i].center -= new Vector3(-1, 0, 0);
            //}
            //if (!orbitDatas[i].StartFromCentre)
            //{
            if (orbitDatas.TakeX)
            {
                orbitDatas.center -= new Vector3(1, 0, 0);
            }
            else
                orbitDatas.center -= new Vector3(0, 1, 0);
            //}
            //else
            //{ 
            if (orbitDatas.thisOrbitType == OrbitType.SPIRAL)
            {
                orbitDatas.center = orbitDatas.StartFromCentre ? orbitDatas.center.normalized * 2f : orbitDatas.center.normalized;

            }
            //else
            //{ 


            //}
            //
            //}


            //orbitDatas[i].center -= orbitDatas[i].center.normalized;
            //set up relative centers 

            orbitDatas.StartRelCenter = orbitDatas.StartVector - orbitDatas.center;
            orbitDatas.EndRelCenter = orbitDatas.EndVector - orbitDatas.center;



            //set up center pos


            //____________________________________________________________
            ///////////////////////ROTATION////////////////
            // ___________________________________________________________
        }
        //ESTABLISH AND ASSIGNS OUR START AND END DIRECTIONA
        public void AssignOrbitDirection()
        {

            //Check/ assign Start if not zero it is a custom vector 
            orbitDatas.StartVector = (orbitDatas.StartVector == Vector3.zero) ? GetRelativeDirection(orbitDatas.StartDirection) * orbitDatas.StartMultiplier : orbitDatas.StartVector;

            //Check/ assign Start if not zero it is a custom vector 
            orbitDatas.EndVector = (orbitDatas.EndVector == Vector3.zero) ? GetRelativeDirection(orbitDatas.EndDirection) * orbitDatas.EndMultiplier : orbitDatas.EndVector;

        }

        public Vector3 GetRelativeDirection(RotationDirection DirectionEnum)

        {


            switch (DirectionEnum)
            {
                case RotationDirection.CUSTOM:
                    //return related vector
                    return new Vector3(0, 0, 0);

                case RotationDirection.UP:
                    //return related vector
                    return new Vector3(0, 1, 0);

                case RotationDirection.UPRIGHT:
                    //return related vector
                    return new Vector3(0.5f, 0.5f, 0);

                case RotationDirection.RIGHT:
                    //return related vector
                    return new Vector3(1, 0, 0);

                case RotationDirection.DOWNRIGHT:
                    //return related vector
                    return new Vector3(0.5f, -0.5f, 0);

                case RotationDirection.DOWN:
                    //return related vector
                    return new Vector3(0, -1, 0);

                case RotationDirection.DOWNLEFT:
                    //return related vector
                    return new Vector3(-0.5f, -0.5f, 0);

                case RotationDirection.LEFT:
                    //return related vector
                    return new Vector3(-1, 0, 0);

                case RotationDirection.UPLEFT:
                    //return related vector
                    return new Vector3(-0.5f, 0.5f, 0);

              


            }
            return new Vector3(0, 0, 0);


        }


        public void SetStartTime()
        {
            overallStartTime = Time.time;
        }

        //this will give us a 0-1 scaler for the time duration
        public float TimeBasedCalculateJourneyTime()
        {




            float fracComplete = (Time.time - overallStartTime) / overallDurationTime;
            return fracComplete;
        }
        public void ConfigureOverallTime()
        {
            overallDurationTime = 0f;
            
                overallDurationTime += orbitDatas.TimedDuration;

           
        }
        // ___________________________The Lerp________________________________
        //                            Lerp Unclamped
        // __________________________________________________________________________________________

        //public void SlerpUnclamped(float percent)
        //{
        //    ////X
        //    //float X = (float)Mathf.LerpUnclamped(StartVector.x, EndVector.x, percent * xMultiplier);
        //    ////Y
        //    //float Y = (float)Mathf.LerpUnclamped(StartVector.y, EndVector.y, percent * yMultiplier);

        //    // ___________________________Move Locally?________________________________

        //    //move locally
        //    if (RotateLocally)
        //    {
        //        //TransformToRotate.localPosition = new Vector3(X, Y, 0f);
        //    }
        //    else //move worldspace
        //        //TransformToRotate.position = new Vector3(X, Y, 0);
        //}
        //// ___________________________The Lerp________________________________
        ////                            Lerp Normal
        //// __________________________________________________________________________________________
        //public void SlerpClamped(float percent)
        //{
        //    //X
        //    //float X = (float)Mathf.Lerp(StartVector.x, EndVector.x, percent * xMultiplier);

        //    //Y
        //    //float Y = (float)Mathf.Lerp(StartVector.y, EndVector.y, percent * yMultiplier);

        //    // ___________________________Move Locally?________________________________
        //    //move locally
        //    if (RotateLocally)
        //    {
        //        //-WINGS-Rotation lerp

        //        //Wing Left Rotation
        //        // TransformToRotate.localRotation = Quaternion.LookRotation(Vector3.forward, new Vector3(X,Y,0));
        //    }
        //    else //move worldspace 
        //        //TransformToRotate.localRotation = Quaternion.LookRotation(Vector3.forward, new Vector3(X, Y, 0));

        //}
        public Vector3 GetPosition()
        {

            return orbitDatas.TransformOrbitPos;
        }
        public Vector3 VectorLerp(float percentage)
        {

            return Vector3.Lerp(orbitDatas.StartRelCenter, orbitDatas.EndRelCenter, percentage);

        }

        public Vector3 VectorLerpUnClamped(float percentage)
        {
            return Vector3.LerpUnclamped(orbitDatas.StartRelCenter, orbitDatas.EndRelCenter, percentage);


        }
        public Vector3 VectorSlerp(float percentage)
        {
            return Vector3.Slerp(orbitDatas.StartRelCenter, orbitDatas.EndRelCenter, percentage);



        }
        public Vector3 VectorSlerpUnClamped(float percentage)
        {
            return Vector3.SlerpUnclamped(orbitDatas.StartRelCenter, orbitDatas.EndRelCenter, percentage);


        }

        ////this is for the editor tool so we can set it to the current 
        //public void SetToCurrent(ref Vector3 toSetToCurrent)
        //{
        //    toSetToCurrent = TransformToRotate.position;
        //}

        public void StartFinished(bool Start)
        {
            if (!Start)
            {


                //TransformToRotate = Quaternion.LookRotation(Vector3.forward, Vector3.up);
            }
            if (Start)
            {
                //SequentialLerp.ConfigureIndex(0.1f);
                AssignOrbitDirection();
                SetStartTime();
                OrbitSetUp();
                ConfigureOverallTime();

            }
        }
    }
}
