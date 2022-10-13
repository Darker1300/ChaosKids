using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 using System;
using Shapes;
namespace AnimationLibrary
{
    [Serializable]

    public class LerpShapeScale
    {
        Disc poop;
        Triangle tri;

        [SerializeField]
        private WhichPosEnd whichPosEnd;


        [SerializeField]
        PosReturn sizeReturn;
        public float FinishedSize;
        public float PriorSize;
        public float DefaultSize;
        public bool StartCurrentSize;
        public bool EndCurrentSize;

        public LerpWithinFactor SequentialLerp;
        public List<LerpShapeScaleData> lerpScaleDatas = new List<LerpShapeScaleData>();
        private float overallStartTime;
        public float overallDurationTime;
        public bool OverallTimeComplete;

        //-------SETUP-------------
        public void StartFinished(bool Start)
        {
            if (!Start)
            {
                // tri.ScaleMode =Shapes.ScaleMode.Coordinate;

            }
            if (Start)
            {
                //AssignDirection();
                SetStartTime();
                ConfigureOverallTime();
                // EndPos();
            }
        }

        public void EndPos()
        {
            switch (whichPosEnd)
            {
                case WhichPosEnd.MYPOSPRIOR:
                    FinishedSize = PriorSize;
                    break;
                case WhichPosEnd.DEFAULTCOLOR:
                    FinishedSize = DefaultSize;
                    break;
                case WhichPosEnd.STARTPOS:
                    FinishedSize = lerpScaleDatas[0].StartSize;
                    break;
                case WhichPosEnd.ENDPOS:
                    FinishedSize = lerpScaleDatas[lerpScaleDatas.Count - 1].EndSize;
                    break;
                default:
                    break;
            }

        }
        //-------Lerp Function-------------


        public void ScaleLerp(float percent)
        {
            if (lerpScaleDatas[SequentialLerp.rangeIndex].Active)
            {

                switch (lerpScaleDatas[SequentialLerp.rangeIndex].thisScaleLerpType)
                {
                    case ScaleShapeLerpType.LERP:

                        //if timed lerp to time value else use percentage
                        Lerp(percent);

                        break;

                    case ScaleShapeLerpType.LERPUNCLAMPED:

                        //if timed lerp to time value else use percentage

                        LerpUnclamped(percent);

                        // TransformToRotate.localRotation = Timed ? Quaternion.LookRotation(Vector3.forward, VectorLerpUnClamped(TimeBasedCalculateJourneyTime())) : Quaternion.LookRotation(Vector3.forward, VectorLerpUnClamped(percentage));

                        break;

                    case ScaleShapeLerpType.LERPANGLE:

                        //if timed lerp to time value else use percentage
                        LerpAngle(percent);


                        //TransformToRotate.localRotation = Timed ? Quaternion.LookRotation(Vector3.forward, VectorSlerp(TimeBasedCalculateJourneyTime())) : Quaternion.LookRotation(Vector3.forward, VectorSlerp(percentage));

                        break;

                  

                }

            }

        }

        public void LerpUnclamped(float percent)
        {
            if (lerpScaleDatas[SequentialLerp.rangeIndex].Timed)
            {
                Debug.Log("TimeComp " + OverallTimeComplete);



                //LERP TIMED
                //float time = TimeBasedCalculateJourneyTime();
                //X

                //float X = (float)Mathf.LerpUnclamped(lerpScaleDatas[SequentialLerp.rangeIndex].StartVector.x, lerpScaleDatas[SequentialLerp.rangeIndex].EndVector.x, TimeBasedCalculateJourneyTime() * ((CustomTransCompMulti.x != 0) ? CustomTransCompMulti.x : lerpScaleDatas[SequentialLerp.rangeIndex].xMultiplier));
                ////Y
                //float Y = (float)Mathf.LerpUnclamped(lerpScaleDatas[SequentialLerp.rangeIndex].StartVector.y, lerpScaleDatas[SequentialLerp.rangeIndex].EndVector.y, TimeBasedCalculateJourneyTime() * ((CustomTransCompMulti.y != 0) ? CustomTransCompMulti.y : lerpScaleDatas[SequentialLerp.rangeIndex].yMultiplier));

                //position = new Vector3(X, Y, 0f);

                lerpScaleDatas[SequentialLerp.rangeIndex].ShapeCurrentScale =Mathf.LerpUnclamped(lerpScaleDatas[SequentialLerp.rangeIndex].StartSize, lerpScaleDatas[SequentialLerp.rangeIndex].EndSize, lerpScaleDatas[SequentialLerp.rangeIndex].animationCurve.Evaluate(SequentialLerp.GetZeroToOneLerpValueFromMainLerpValue(TimeBasedCalculateJourneyTime())) * lerpScaleDatas[SequentialLerp.rangeIndex].xMultiplier);

            }
            else
            {
                //simple vector lerp maybe have scale in directions
                lerpScaleDatas[SequentialLerp.rangeIndex].ShapeCurrentScale = Mathf.LerpUnclamped(lerpScaleDatas[SequentialLerp.rangeIndex].StartSize, lerpScaleDatas[SequentialLerp.rangeIndex].EndSize, lerpScaleDatas[SequentialLerp.rangeIndex].animationCurve.Evaluate(SequentialLerp.GetZeroToOneLerpValueFromMainLerpValue(percent)));
                ////LERP PERCENT
                //float X = (float)Mathf.Lerp(lerpScaleDatas[SequentialLerp.rangeIndex].StartVector.x, lerpScaleDatas[SequentialLerp.rangeIndex].EndVector.x, lerpScaleDatas[SequentialLerp.rangeIndex].animationCurveX.Evaluate(percent) * ((CustomTransCompMulti.x != 0) ? CustomTransCompMulti.x : lerpScaleDatas[SequentialLerp.rangeIndex].xMultiplier));
                ////Y
                //float Y = (float)Mathf.Lerp(lerpScaleDatas[SequentialLerp.rangeIndex].StartVector.y, lerpScaleDatas[SequentialLerp.rangeIndex].EndVector.y, lerpScaleDatas[SequentialLerp.rangeIndex].animationCurveX.Evaluate(percent) * ((CustomTransCompMulti.y != 0) ? CustomTransCompMulti.y : lerpScaleDatas[SequentialLerp.rangeIndex].yMultiplier));

                //position = new Vector3(X, Y, 0f);

            }

        }

        public void Lerp(float percent)
        {
            if (lerpScaleDatas[SequentialLerp.rangeIndex].Timed)
            {
                Debug.Log("TimeComp " + OverallTimeComplete);


                {
                    //LERP TIMED
                    //float time = TimeBasedCalculateJourneyTime();
                    //X

                    //float X = (float)Mathf.LerpUnclamped(lerpScaleDatas[SequentialLerp.rangeIndex].StartVector.x, lerpScaleDatas[SequentialLerp.rangeIndex].EndVector.x, TimeBasedCalculateJourneyTime() * ((CustomTransCompMulti.x != 0) ? CustomTransCompMulti.x : lerpScaleDatas[SequentialLerp.rangeIndex].xMultiplier));
                    ////Y
                    //float Y = (float)Mathf.LerpUnclamped(lerpScaleDatas[SequentialLerp.rangeIndex].StartVector.y, lerpScaleDatas[SequentialLerp.rangeIndex].EndVector.y, TimeBasedCalculateJourneyTime() * ((CustomTransCompMulti.y != 0) ? CustomTransCompMulti.y : lerpScaleDatas[SequentialLerp.rangeIndex].yMultiplier));

                    //position = new Vector3(X, Y, 0f);

                    lerpScaleDatas[SequentialLerp.rangeIndex].ShapeCurrentScale = Mathf.Lerp(lerpScaleDatas[SequentialLerp.rangeIndex].StartSize, lerpScaleDatas[SequentialLerp.rangeIndex].EndSize, lerpScaleDatas[SequentialLerp.rangeIndex].animationCurve.Evaluate(SequentialLerp.GetZeroToOneLerpValueFromMainLerpValue(TimeBasedCalculateJourneyTime())) * lerpScaleDatas[SequentialLerp.rangeIndex].xMultiplier);
                }
            }
            else
            {
                //simple vector lerp maybe have scale in directions
                lerpScaleDatas[SequentialLerp.rangeIndex].ShapeCurrentScale = Mathf.Lerp(lerpScaleDatas[SequentialLerp.rangeIndex].StartSize, lerpScaleDatas[SequentialLerp.rangeIndex].EndSize, lerpScaleDatas[SequentialLerp.rangeIndex].animationCurve.Evaluate(percent) * lerpScaleDatas[SequentialLerp.rangeIndex].xMultiplier);
                ////LERP PERCENT
                //float X = (float)Mathf.Lerp(lerpScaleDatas[SequentialLerp.rangeIndex].StartVector.x, lerpScaleDatas[SequentialLerp.rangeIndex].EndVector.x, lerpScaleDatas[SequentialLerp.rangeIndex].animationCurveX.Evaluate(percent) * ((CustomTransCompMulti.x != 0) ? CustomTransCompMulti.x : lerpScaleDatas[SequentialLerp.rangeIndex].xMultiplier));
                ////Y
                //float Y = (float)Mathf.Lerp(lerpScaleDatas[SequentialLerp.rangeIndex].StartVector.y, lerpScaleDatas[SequentialLerp.rangeIndex].EndVector.y, lerpScaleDatas[SequentialLerp.rangeIndex].animationCurveX.Evaluate(percent) * ((CustomTransCompMulti.y != 0) ? CustomTransCompMulti.y : lerpScaleDatas[SequentialLerp.rangeIndex].yMultiplier));

                //position = new Vector3(X, Y, 0f);

            }

        }

        public void LerpAngle(float percent)
        {
            if (lerpScaleDatas[SequentialLerp.rangeIndex].Timed)
            {
                Debug.Log("TimeComp " + OverallTimeComplete);


                {
                    //LERP TIMED
                    //float time = TimeBasedCalculateJourneyTime();
                    //X

                    //float X = (float)Mathf.LerpUnclamped(lerpScaleDatas[SequentialLerp.rangeIndex].StartVector.x, lerpScaleDatas[SequentialLerp.rangeIndex].EndVector.x, TimeBasedCalculateJourneyTime() * ((CustomTransCompMulti.x != 0) ? CustomTransCompMulti.x : lerpScaleDatas[SequentialLerp.rangeIndex].xMultiplier));
                    ////Y
                    //float Y = (float)Mathf.LerpUnclamped(lerpScaleDatas[SequentialLerp.rangeIndex].StartVector.y, lerpScaleDatas[SequentialLerp.rangeIndex].EndVector.y, TimeBasedCalculateJourneyTime() * ((CustomTransCompMulti.y != 0) ? CustomTransCompMulti.y : lerpScaleDatas[SequentialLerp.rangeIndex].yMultiplier));

                    //position = new Vector3(X, Y, 0f);

                    lerpScaleDatas[SequentialLerp.rangeIndex].ShapeCurrentScale = Mathf.LerpAngle(lerpScaleDatas[SequentialLerp.rangeIndex].StartSize, lerpScaleDatas[SequentialLerp.rangeIndex].EndSize, lerpScaleDatas[SequentialLerp.rangeIndex].animationCurve.Evaluate(SequentialLerp.GetZeroToOneLerpValueFromMainLerpValue(TimeBasedCalculateJourneyTime())) * lerpScaleDatas[SequentialLerp.rangeIndex].xMultiplier);
                }
            }
            else
            {
                //simple vector lerp maybe have scale in directions
                lerpScaleDatas[SequentialLerp.rangeIndex].ShapeCurrentScale = Mathf.LerpAngle(lerpScaleDatas[SequentialLerp.rangeIndex].StartSize, lerpScaleDatas[SequentialLerp.rangeIndex].EndSize, lerpScaleDatas[SequentialLerp.rangeIndex].animationCurve.Evaluate(percent) * lerpScaleDatas[SequentialLerp.rangeIndex].xMultiplier);
                ////LERP PERCENT
                //float X = (float)Mathf.Lerp(lerpScaleDatas[SequentialLerp.rangeIndex].StartVector.x, lerpScaleDatas[SequentialLerp.rangeIndex].EndVector.x, lerpScaleDatas[SequentialLerp.rangeIndex].animationCurveX.Evaluate(percent) * ((CustomTransCompMulti.x != 0) ? CustomTransCompMulti.x : lerpScaleDatas[SequentialLerp.rangeIndex].xMultiplier));
                ////Y
                //float Y = (float)Mathf.Lerp(lerpScaleDatas[SequentialLerp.rangeIndex].StartVector.y, lerpScaleDatas[SequentialLerp.rangeIndex].EndVector.y, lerpScaleDatas[SequentialLerp.rangeIndex].animationCurveX.Evaluate(percent) * ((CustomTransCompMulti.y != 0) ? CustomTransCompMulti.y : lerpScaleDatas[SequentialLerp.rangeIndex].yMultiplier));

                //position = new Vector3(X, Y, 0f);

            }

        }

        //public void SlerpUnclamped(float percent)
        //{
        //    if (lerpScaleDatas[SequentialLerp.rangeIndex].Timed)
        //    {
        //        Debug.Log("TimeComp " + OverallTimeComplete);


        //        {
        //            //LERP TIMED
        //            //float time = TimeBasedCalculateJourneyTime();
        //            //X

        //            //float X = (float)Mathf.LerpUnclamped(lerpScaleDatas[SequentialLerp.rangeIndex].StartVector.x, lerpScaleDatas[SequentialLerp.rangeIndex].EndVector.x, TimeBasedCalculateJourneyTime() * ((CustomTransCompMulti.x != 0) ? CustomTransCompMulti.x : lerpScaleDatas[SequentialLerp.rangeIndex].xMultiplier));
        //            ////Y
        //            //float Y = (float)Mathf.LerpUnclamped(lerpScaleDatas[SequentialLerp.rangeIndex].StartVector.y, lerpScaleDatas[SequentialLerp.rangeIndex].EndVector.y, TimeBasedCalculateJourneyTime() * ((CustomTransCompMulti.y != 0) ? CustomTransCompMulti.y : lerpScaleDatas[SequentialLerp.rangeIndex].yMultiplier));

        //            //position = new Vector3(X, Y, 0f);

        //            lerpScaleDatas[SequentialLerp.rangeIndex].TransformScale = Vector3.SlerpUnclamped(lerpScaleDatas[SequentialLerp.rangeIndex].StartSize, lerpScaleDatas[SequentialLerp.rangeIndex].EndSize, lerpScaleDatas[SequentialLerp.rangeIndex].animationCurve.Evaluate(SequentialLerp.GetZeroToOneLerpValueFromMainLerpValue(TimeBasedCalculateJourneyTime())) * lerpScaleDatas[SequentialLerp.rangeIndex].xMultiplier);
        //        }
        //    }
        //    else
        //    {
        //        //simple vector lerp maybe have scale in directions
        //        lerpScaleDatas[SequentialLerp.rangeIndex].TransformScale = Vector3.SlerpUnclamped(lerpScaleDatas[SequentialLerp.rangeIndex].StartSize, lerpScaleDatas[SequentialLerp.rangeIndex].EndSize, lerpScaleDatas[SequentialLerp.rangeIndex].animationCurve.Evaluate(percent) * lerpScaleDatas[SequentialLerp.rangeIndex].xMultiplier);
        //        ////LERP PERCENT
        //        //float X = (float)Mathf.Lerp(lerpScaleDatas[SequentialLerp.rangeIndex].StartVector.x, lerpScaleDatas[SequentialLerp.rangeIndex].EndVector.x, lerpScaleDatas[SequentialLerp.rangeIndex].animationCurveX.Evaluate(percent) * ((CustomTransCompMulti.x != 0) ? CustomTransCompMulti.x : lerpScaleDatas[SequentialLerp.rangeIndex].xMultiplier));
        //        ////Y
        //        //float Y = (float)Mathf.Lerp(lerpScaleDatas[SequentialLerp.rangeIndex].StartVector.y, lerpScaleDatas[SequentialLerp.rangeIndex].EndVector.y, lerpScaleDatas[SequentialLerp.rangeIndex].animationCurveX.Evaluate(percent) * ((CustomTransCompMulti.y != 0) ? CustomTransCompMulti.y : lerpScaleDatas[SequentialLerp.rangeIndex].yMultiplier));

        //        //position = new Vector3(X, Y, 0f);

        //    }

        //}


        //-------DIRECTION-------------
        //public void AssignDirection()
        //{
        //    for (int i = 0; i < lerpTransDatas.Count; i++)
        //    {

        //        //Check/ assign Start if not zero it is a custom vector 
        //        lerpTransDatas[i].StartVector = (lerpTransDatas[i].StartDirection != RotationDirection.CUSTOM) ? (GetRelativeDirection(lerpTransDatas[i].StartDirection) * lerpTransDatas[i].StartMultiplier) : lerpTransDatas[i].StartVector;

        //        //Check/ assign Start if not zero it is a custom vector 
        //        lerpTransDatas[i].EndVector = (lerpTransDatas[i].EndDirection != RotationDirection.CUSTOM) ? (GetRelativeDirection(lerpTransDatas[i].EndDirection) * lerpTransDatas[i].EndMultiplier) : lerpTransDatas[i].EndVector;

        //    }

        //}
        //public Vector2 GetRelativeDirection(RotationDirection DirectionEnum)

        //{
        //    switch (DirectionEnum)
        //    {
        //        case RotationDirection.CUSTOM:
        //            //return related vector
        //            return new Vector2(0, 1);

        //        case RotationDirection.UP:
        //            //return related vector
        //            return new Vector2(0, 1);

        //        case RotationDirection.UPRIGHT:
        //            //return related vector
        //            return new Vector2(0.5f, 0.5f);

        //        case RotationDirection.RIGHT:
        //            //return related vector
        //            return new Vector2(1, 0);

        //        case RotationDirection.DOWNRIGHT:
        //            //return related vector
        //            return new Vector2(0.5f, -0.5f);

        //        case RotationDirection.DOWN:
        //            //return related vector
        //            return new Vector2(0, -1);

        //        case RotationDirection.DOWNLEFT:
        //            //return related vector
        //            return new Vector2(-0.5f, -0.5f);

        //        case RotationDirection.LEFT:
        //            //return related vector
        //            return new Vector2(-1, 0);

        //        case RotationDirection.UPLEFT:
        //            //return related vector
        //            return new Vector2(-0.5f, 0.5f);
        //    }
        //    return new Vector2(0, 0);


        //}




        //}

        //-------LERP-------------


        //Scale Object 

        //Scale Shape

        //-------TimeSetUpCalculation-------------
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
            for (int i = 0; i < lerpScaleDatas.Count; i++)

            {
                overallDurationTime += lerpScaleDatas[i].TimedDuration;

            }
        }


    }



    ///

    ///
    ///
    ///
    ///
    ///
    ///
    ///
    ///
    ///
    ///
}