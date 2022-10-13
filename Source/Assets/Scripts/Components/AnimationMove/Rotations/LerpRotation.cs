using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AnimationLibrary
{
    public enum OurLerpType
    {
        LERP, LERPUNCLAMPED, SLERP, SLERPUNCLAMPED

    }

    public enum RotationDirection
    {
        CUSTOM, UP, DOWN, LEFT, RIGHT, UPRIGHT, DOWNRIGHT, UPLEFT, DOWNLEFT, CURRENTPOSITION

    }



    [Serializable]
    public class LerpRotation
    {
        ///this will tell how much of the parent lerp it belongs to
        //[SerializeField]
        //[Range(0, 1)]
        //float[] lerpRange;
        // public int SequentialLerp.rangeIndex = 0;
        public LerpWithinFactor SequentialLerp;
        public List<RotationData> rotationDatas = new List<RotationData>();
        //int lerpIndexer;
        /////////////////////////////////////////////////////////////////
        public float overallStartTime;
        public float overallDurationTime;

        /// <summary>
        /// 
        /// 
        /// so if has multiple rotation do this 
        /// once rotated its amount do normal start to end
        /// Rotate back amount if it doesnt have mutliple Rotates back 
        /// else Do multiple 
        /// then go from that rotation to end
        /// 
        /// 
        /// 
        /// </summary>
        /// <param name="percentage"></param>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////
        //public void GetIndexer(float percent)
        //{
        //    if (SequentialLerp.rangeIndex != 0)
        //    {
        //        //if ((percent - rotationData[SequentialLerp.rangeIndex].lerpRange) * (lerpRange[lerpIndexer + 1] - percent) > 0)
        //        //{

        //        //}//else find where we are now 
        //    }
        //    else
        //    if ((percent * rotationData[SequentialLerp.rangeIndex].lerpRange) > 0 )
        //    {



        //    }//else find where we are now 
        //}
        //public void UpdateIndexer(float percent, ref int indexer)
        //{

        //}
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////
        public void HowToLerpRotation(float percentage)
        {
            if (rotationDatas[SequentialLerp.rangeIndex].Active)
            {
                // rotationDatas[SequentialLerp.rangeIndex].currentRotation = rotationDatas[SequentialLerp.rangeIndex].Timed ? Quaternion.Slerp(rotationDatas[SequentialLerp.rangeIndex].StartRotation, rotationDatas[SequentialLerp.rangeIndex].EndRotation, SequentialLerp.GetZeroToOneLerpValueFromMainLerpValue(TimeBasedCalculateJourneyTime())) : Quaternion.Slerp(rotationDatas[SequentialLerp.rangeIndex].StartRotation, rotationDatas[SequentialLerp.rangeIndex].EndRotation, percentage * rotationDatas[SequentialLerp.rangeIndex].RotateMultiplier);


                float zRotation = rotationDatas[SequentialLerp.rangeIndex].Timed ? Mathf.Lerp(rotationDatas[SequentialLerp.rangeIndex].startRotationZ, rotationDatas[SequentialLerp.rangeIndex].endRotationZ, rotationDatas[SequentialLerp.rangeIndex].animationCurve.Evaluate(SequentialLerp.GetZeroToOneLerpValueFromMainLerpValue( TimeBasedCalculateJourneyTime() % 360.0f) )) * rotationDatas[SequentialLerp.rangeIndex].RotateMultiplier : Mathf.Lerp(rotationDatas[SequentialLerp.rangeIndex].startRotationZ, rotationDatas[SequentialLerp.rangeIndex].endRotationZ, rotationDatas[SequentialLerp.rangeIndex].animationCurve.Evaluate(SequentialLerp.GetZeroToOneLerpValueFromMainLerpValue(percentage ) % 360.0f) ) ;
                rotationDatas[SequentialLerp.rangeIndex].currentRotation = Quaternion.AngleAxis(zRotation, Vector3.forward);

               // RotateMoreThanOnce(percentage);
                //rotationDatas[SequentialLerp.rangeIndex].currentRotation = rotationDatas[SequentialLerp.rangeIndex].Timed ? Quaternion.Slerp(rotationDatas[SequentialLerp.rangeIndex].StartRotation, rotationDatas[SequentialLerp.rangeIndex].EndRotation, SequentialLerp.GetZeroToOneLerpValueFromMainLerpValue(TimeBasedCalculateJourneyTime())) : Quaternion.Slerp(rotationDatas[SequentialLerp.rangeIndex].StartRotation, rotationDatas[SequentialLerp.rangeIndex].EndRotation, percentage * rotationDatas[SequentialLerp.rangeIndex].RotateMultiplier);


                //switch (rotationDatas[SequentialLerp.rangeIndex].thisRotationLerpType)
                //{
                //    case RotationLerpType.LERP:
                //        // 
                //        //if timed lerp to time value else use percentage
                //        //ROTATION
                //        rotationDatas[SequentialLerp.rangeIndex].currentRotation = rotationDatas[SequentialLerp.rangeIndex].Timed ? Quaternion.Lerp(rotationDatas[SequentialLerp.rangeIndex].StartRotation, rotationDatas[SequentialLerp.rangeIndex].EndRotation, TimeBasedCalculateJourneyTime()) : Quaternion.Lerp(rotationDatas[SequentialLerp.rangeIndex].StartRotation, rotationDatas[SequentialLerp.rangeIndex].EndRotation, percentage);

                //        break;

                //    case RotationLerpType.LERPUNCLAMPED:
                //        //ROTATION
                //        rotationDatas[SequentialLerp.rangeIndex].currentRotation = rotationDatas[SequentialLerp.rangeIndex].Timed ? Quaternion.LerpUnclamped(rotationDatas[SequentialLerp.rangeIndex].StartRotation, rotationDatas[SequentialLerp.rangeIndex].EndRotation, TimeBasedCalculateJourneyTime() * rotationDatas[SequentialLerp.rangeIndex].RotateMultiplier) : Quaternion.LerpUnclamped(rotationDatas[SequentialLerp.rangeIndex].StartRotation, rotationDatas[SequentialLerp.rangeIndex].EndRotation, percentage * rotationDatas[SequentialLerp.rangeIndex].RotateMultiplier);

                //        break;

                //    case RotationLerpType.SLERP:
                //        //ROTATION
                //        rotationDatas[SequentialLerp.rangeIndex].currentRotation = rotationDatas[SequentialLerp.rangeIndex].Timed ? Quaternion.Slerp(rotationDatas[SequentialLerp.rangeIndex].StartRotation, rotationDatas[SequentialLerp.rangeIndex].EndRotation, SequentialLerp.GetZeroToOneLerpValueFromMainLerpValue(TimeBasedCalculateJourneyTime())) : Quaternion.Slerp(rotationDatas[SequentialLerp.rangeIndex].StartRotation, rotationDatas[SequentialLerp.rangeIndex].EndRotation, percentage * rotationDatas[SequentialLerp.rangeIndex].RotateMultiplier);


                //        break;

                //    case RotationLerpType.SLERPUNCLAMPED:
                //        //ROTATION
                //        rotationDatas[SequentialLerp.rangeIndex].currentRotation = rotationDatas[SequentialLerp.rangeIndex].Timed ? Quaternion.SlerpUnclamped(rotationDatas[SequentialLerp.rangeIndex].StartRotation, rotationDatas[SequentialLerp.rangeIndex].EndRotation, TimeBasedCalculateJourneyTime() * rotationDatas[SequentialLerp.rangeIndex].RotateMultiplier) : Quaternion.SlerpUnclamped(rotationDatas[SequentialLerp.rangeIndex].StartRotation, rotationDatas[SequentialLerp.rangeIndex].EndRotation, percentage * rotationDatas[SequentialLerp.rangeIndex].RotateMultiplier);

                //        break;


                //}

                //switch (thisRotationLerpType)
                //{
                //    case RotationLerpType.LERP:
                //        // 


                //        //if timed lerp to time value else use percentage
                //        //ROTATION
                //        //TransformToRotate.localRotation = Timed ? Quaternion.Lerp(Vector3.forward, VectorLerp(TimeBasedCalculateJourneyTime())) : Quaternion.LookRotation(Vector3.forward, VectorLerp(percentage));
                //        currentRotation = Timed ? Quaternion.Lerp(StartRotation, EndRotation, TimeBasedCalculateJourneyTime()) : Quaternion.Lerp(StartRotation, EndRotation, percentage);

                //        break;

                //    case RotationLerpType.LERPUNCLAMPED:
                //        //ROTATION
                //        currentRotation = Timed ? Quaternion.LerpUnclamped(StartRotation, EndRotation, TimeBasedCalculateJourneyTime() * RotateMultiplier) : Quaternion.LerpUnclamped(StartRotation, EndRotation, percentage * RotateMultiplier);

                //        // TransformToRotate.localRotation = Timed ? Quaternion.LookRotation(Vector3.forward, VectorLerpUnClamped(TimeBasedCalculateJourneyTime())) : Quaternion.LookRotation(Vector3.forward, VectorLerpUnClamped(percentage));

                //        break;

                //    case RotationLerpType.SLERP:
                //        //ROTATION
                //        currentRotation = Timed ? Quaternion.Slerp(StartRotation, EndRotation, TimeBasedCalculateJourneyTime() * RotateMultiplier) : Quaternion.Slerp(StartRotation, EndRotation, percentage * RotateMultiplier);

                //        //TransformToRotate.localRotation = Timed ? Quaternion.LookRotation(Vector3.forward, VectorSlerp(TimeBasedCalculateJourneyTime())) : Quaternion.LookRotation(Vector3.forward, VectorSlerp(percentage));

                //        break;

                //    case RotationLerpType.SLERPUNCLAMPED:
                //        //ROTATION
                //        currentRotation = Timed ? Quaternion.SlerpUnclamped(StartRotation, EndRotation, TimeBasedCalculateJourneyTime() * RotateMultiplier) : Quaternion.SlerpUnclamped(StartRotation, EndRotation, percentage * RotateMultiplier);

                //        // TransformToRotate.localRotation = Timed ? Quaternion.LookRotation(Vector3.forward, VectorSlerpUnClamped(TimeBasedCalculateJourneyTime())) : Quaternion.LookRotation(Vector3.forward, VectorSlerpUnClamped(percentage));
                //        break;


                //}

            }

        }



        private void CalculateRotationsOldWay()
        {
            //////////////////////////////////////////////////
            int i = 0;
            foreach (var rotatiodata in rotationDatas)
            {

                float angle = Vector2.SignedAngle(rotationDatas[i].StartVector.normalized, rotationDatas[i].EndVector.normalized);
                rotationDatas[i].EndRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                rotationDatas[i].StartRotation = Quaternion.LookRotation(Vector3.forward, rotationDatas[i].StartVector);
                i++;
            }

            ////////////////////////////////////////
        }

        private void CalculateRotations()
        {
            //////////////////////////////////////////////////
            

                 CalculateMultipleRotationCustomFinish();
            //CalculateMultipleRotation();

            ////////////////////////////////////////
        }

        private void CalculateMultipleRotationCustomFinish()
        {
        //////////////////////////////////////////////////
        //float angle = Vector2.SignedAngle(StartVector.normalized, EndVector.normalized);
        // EndRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //StartRotation = Quaternion.LookRotation(Vector3.forward, StartVector);
        ////////////////////////////////////////
        int i = 0;
           

        foreach (var rotatiodata in rotationDatas)
        {
            rotationDatas[i].startRotationZ = Mathf.Atan2(-rotationDatas[i].StartVector.normalized.x, rotationDatas[i].StartVector.normalized.y) * Mathf.Rad2Deg ;
            rotationDatas[i].endRotationDirectionZ = Mathf.Atan2(-rotationDatas[i].EndVector.normalized.x, rotationDatas[i].EndVector.normalized.y) * Mathf.Rad2Deg;
                
                //float angle = ((rotationDatas[i].RotateForward) ? (rotationDatas[i].startRotationZ - rotationDatas[i].endRotationDirectionZ) + 360 : rotationDatas[i].startRotationZ - rotationDatas[i].endRotationDirectionZ);
                //float angle = (rotationDatas[i].startRotationZ - rotationDatas[i].endRotationDirectionZ);
                
            rotationDatas[i].endRotationZ = (rotationDatas[i].startRotationZ + ((rotationDatas[i].RotateForward) ? rotationDatas[i].RotationAmount : -rotationDatas[i].RotationAmount) * 360f)+ Vector2.SignedAngle(rotationDatas[i].StartVector, rotationDatas[i].EndVector);
            //fix this potato CODE!!!
            
                i++;
            }
        }

        private void CalculateMultipleRotation()
        {
            int i = 0;
            foreach (var rotatiodata in rotationDatas)
            {
                float startRotationZ = Mathf.Atan2(-rotationDatas[i].StartVector.x, rotationDatas[i].StartVector.y) * Mathf.Rad2Deg;
                float endRotation = (startRotationZ + ((rotationDatas[i].RotateForward) ? rotationDatas[i].RotationAmount : -rotationDatas[i].RotationAmount) * 360f);

                i++;
            }
           
        }
        //rotates the amount of times then will finish pas back to standard Rotate 
        private void RotateMoreThanOnce(float percent)
        {
            //float zRotation = Mathf.Lerp(rotationDatas[SequentialLerp.rangeIndex].startRotationZ, rotationDatas[SequentialLerp.rangeIndex].endRotationZ, rotationDatas[SequentialLerp.rangeIndex].downCurve.Evaluate(percent)) % 360.0f;
           // rotationDatas[SequentialLerp.rangeIndex].currentRotation = Quaternion.AngleAxis(zRotation, Vector3.forward);

        }

        //Probably do all at the start so its all set up to go or may cause lag spike so only do as you go 
        //ESTABLISH AND ASSIGNS OUR START AND END DIRECTIONA
        public void AssignDirection()
        {
            int i = 0;
            foreach (var rotatiodata in rotationDatas)
            {
                //Check/ assign Start if not zero it is a custom vector 
                rotationDatas[i].StartVector = (rotationDatas[i].StartVector == Vector3.zero) ? GetRelativeDirection(rotationDatas[i].StartDirection) : rotationDatas[i].StartVector;

                //Check/ assign Start if not zero it is a custom vector 
                rotationDatas[i].EndVector = (rotationDatas[i].EndVector == Vector3.zero) ? GetRelativeDirection(rotationDatas[i].EndDirection) : rotationDatas[i].EndVector;
                i++;
            }

        }
        public void RotTransform(float percent)
        {
        }
        public Vector3 GetRelativeDirection(RotationDirection DirectionEnum)

        {
            switch (DirectionEnum)
            {
                case RotationDirection.CUSTOM:
                    //return related vector
                    return new Vector3(0, 1, 0);

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
            foreach (var rotatiodata in rotationDatas)
            {
                overallDurationTime += rotatiodata.TimedDuration;

            }
        }
        //public Vector3 VectorLerp(float percentage)
        //{

        //   return Vector3.Lerp(StartRelCenter, EndRelCenter, percentage);

        //}

        //public Vector3 VectorLerpUnClamped(float percentage)
        //{
        //    return Vector3.LerpUnclamped(StartRelCenter, EndRelCenter, percentage);

        //}
        //public Vector3 VectorSlerp(float percentage)
        //{
        //    return Vector3.Slerp(StartRelCenter, EndRelCenter, percentage);

        //}
        //public Vector3 VectorSlerpUnClamped(float percentage)
        //{
        //    return Vector3.SlerpUnclamped(StartRelCenter, EndRelCenter, percentage);

        //}

        //this is for the editor tool so we can set it to the current 
        //public void SetToCurrent(ref Vector3 toSetToCurrent)
        //{
        //    toSetToCurrent = TransformToRotate.position;
        //}
        ///WILL NEED TO CYCLE THROUGH ALL
        public void StartFinished(bool Start)
        {
            if (!Start)
            {
                rotationDatas[SequentialLerp.rangeIndex].currentRotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
            }
            if (Start)
            {
                rotationDatas[SequentialLerp.rangeIndex].currentRotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
                AssignDirection();
                SetStartTime();
                //CalculateRotationsOldWay();
                CalculateRotations();
                SequentialLerp.ConfigureIndex(0.1f);
                ConfigureOverallTime();


            }
        }

    }
}
