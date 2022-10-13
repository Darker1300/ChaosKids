using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationLibrary
{
    [Serializable]
    public class LerpPosition
    {
        [SerializeField]
        private WhichPosEnd whichPosEnd;


        [SerializeField]
        PosReturn posReturn;
        public Vector3 FinishedPos;
        public Vector3 PriorPos;
        public Vector3 DefaultPos;
        public bool StartCurrentPos;
        public bool EndCurrentPos;
    
        public LerpWithinFactor SequentialLerp;
        public List<LerpTransformData> lerpTransDatas = new List<LerpTransformData>();
        private float overallStartTime;
        public float overallDurationTime;
        public bool OverallTimeComplete;
        public void MoveTransform(float percent, Vector2 CustomTransCompMulti, ref Vector3 position)
        {
            if (lerpTransDatas[SequentialLerp.rangeIndex].Active)
            {

                //if it is timed and time is complete return false
                if (lerpTransDatas[SequentialLerp.rangeIndex].Timed)
                {
                    if (!OverallTimeComplete)
                    {

                        if (lerpTransDatas[SequentialLerp.rangeIndex].type == lerpType.UNCLAMPED)
                        {
                            LerpUnclamped(percent, CustomTransCompMulti, ref position);

                        }
                        else
                        {
                            LerpClamped(percent, CustomTransCompMulti, ref position);

                        }

                    }
                    else
                    {
                        // THIS TELLS THE RETURN FUNCTION THAT this LERP HAS FINISHED PASSING A BOOL TO TELL ITS NOT THE MAIN ANIMATION COMPONENT LERP THATS COMPLETE BUT This instance
                        ReturnPosition(false);

                    }



                }
                else
                    if (percent != 1)
                {
                    if (lerpTransDatas[SequentialLerp.rangeIndex].type == lerpType.UNCLAMPED)
                    {
                        LerpUnclamped(percent, CustomTransCompMulti, ref position);

                    }
                    else
                    {
                        LerpClamped(percent, CustomTransCompMulti, ref position);


                    }
                }
                else
                {
                    // THIS TELLS THE RETURN FUNCTION THAT this LERP HAS FINISHED PASSING A BOOL TO TELL ITS NOT THE MAIN ANIMATION COMPONENT LERP THATS COMPLETE BUT This instance
                    ReturnPosition(false);

                }


            }

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
            for (int i = 0; i < lerpTransDatas.Count; i++)

            {
                overallDurationTime += lerpTransDatas[i].TimedDuration;

            }
        }

        // ___________________________The Lerp________________________________
        //                            Lerp Unclamped
        // __________________________________________________________________________________________
        public void LerpUnclamped(float percent, Vector2 CustomTransCompMulti, ref Vector3 position)
        {
            if (lerpTransDatas[SequentialLerp.rangeIndex].Timed)
            {
                Debug.Log("TimeComp " + OverallTimeComplete);

                
                {
                    //LERP TIMED
                    //float time = TimeBasedCalculateJourneyTime();
                    //X
                    float X = (float)Mathf.LerpUnclamped(lerpTransDatas[SequentialLerp.rangeIndex].StartVector.x, lerpTransDatas[SequentialLerp.rangeIndex].EndVector.x, TimeBasedCalculateJourneyTime() * ((CustomTransCompMulti.x != 0) ? CustomTransCompMulti.x : lerpTransDatas[SequentialLerp.rangeIndex].xMultiplier));
                    //Y
                    float Y = (float)Mathf.LerpUnclamped(lerpTransDatas[SequentialLerp.rangeIndex].StartVector.y, lerpTransDatas[SequentialLerp.rangeIndex].EndVector.y, TimeBasedCalculateJourneyTime() * ((CustomTransCompMulti.y != 0) ? CustomTransCompMulti.y : lerpTransDatas[SequentialLerp.rangeIndex].yMultiplier));

                    position = new Vector3(X, Y, 0f);

                }
            }
            else
            {
                //LERP PERCENT
                float X = (float)Mathf.Lerp(lerpTransDatas[SequentialLerp.rangeIndex].StartVector.x, lerpTransDatas[SequentialLerp.rangeIndex].EndVector.x, lerpTransDatas[SequentialLerp.rangeIndex].animationCurveX.Evaluate(SequentialLerp.GetZeroToOneLerpValueFromMainLerpValue(percent)) * ((CustomTransCompMulti.x != 0) ? CustomTransCompMulti.x : lerpTransDatas[SequentialLerp.rangeIndex].xMultiplier));
                //Y
                float Y = (float)Mathf.Lerp(lerpTransDatas[SequentialLerp.rangeIndex].StartVector.y, lerpTransDatas[SequentialLerp.rangeIndex].EndVector.y, lerpTransDatas[SequentialLerp.rangeIndex].animationCurveX.Evaluate(SequentialLerp.GetZeroToOneLerpValueFromMainLerpValue(percent)) * ((CustomTransCompMulti.y != 0) ? CustomTransCompMulti.y : lerpTransDatas[SequentialLerp.rangeIndex].yMultiplier));

                position = new Vector3(X, Y, 0f);

            }
            ////X                                                                             //does it have a custom mutiplier                 //this selects what multiplier to use
            //float X = (float)Mathf.LerpUnclamped(StartVector.x, EndVector.x, percent * ((CustomTransCompMulti.x != 0) ? CustomTransCompMulti.x : xMultiplier));
            ////Y
            //float Y = (float)Mathf.LerpUnclamped(StartVector.y, EndVector.y, percent * ((CustomTransCompMulti.y != 0) ? CustomTransCompMulti.y : yMultiplier));
            //return new Vector3(X, Y, 0f);

            // ___________________________Move Locally?________________________________

            //if (lerpTransDatas[SequentialLerp.rangeIndex].Timed)
            //{
            //    Debug.Log("TimeComp " + OverallTimeComplete);


            //    {
            //        //LERP TIMED
            //        float time = TimeBasedCalculateJourneyTime();
            //        //X
            //        float X = (float)Mathf.Lerp(StartVector.x, EndVector.x, ((CustomTransCompMulti.x != 0) ? time * CustomTransCompMulti.x : GetMultiplierX(time)));
            //        //Y
            //        float Y = (float)Mathf.Lerp(StartVector.y, EndVector.y, ((CustomTransCompMulti.y != 0) ? time * CustomTransCompMulti.y : GetMultiplierY(time)));

            //        position = new Vector3(X, Y, 0f);

            //    }
            //}
            //else
            //{
            //    //LERP PERCENT
            //    float X = (float)Mathf.Lerp(StartVector.x, EndVector.x, ((CustomTransCompMulti.x != 0) ? percent * CustomTransCompMulti.x : GetMultiplierX(percent)));
            //    //Y
            //    float Y = (float)Mathf.Lerp(StartVector.y, EndVector.y, ((CustomTransCompMulti.y != 0) ? percent * CustomTransCompMulti.y : GetMultiplierY(percent)));

            //    position = new Vector3(X, Y, 0f);

            //}
        }
        public void AssignDirection()
        {
            for (int i = 0; i < lerpTransDatas.Count; i++)
            {

                //Check/ assign Start if not zero it is a custom vector 
                lerpTransDatas[i].StartVector = (lerpTransDatas[i].StartDirection != RotationDirection.CUSTOM) ? (GetRelativeDirection(lerpTransDatas[i].StartDirection) * lerpTransDatas[i].StartMultiplier) : lerpTransDatas[i].StartVector;

                //Check/ assign Start if not zero it is a custom vector 
                lerpTransDatas[i].EndVector = (lerpTransDatas[i].EndDirection != RotationDirection.CUSTOM) ? (GetRelativeDirection(lerpTransDatas[i].EndDirection) * lerpTransDatas[i].EndMultiplier) : lerpTransDatas[i].EndVector;

            }
           
        }
        public Vector2 GetRelativeDirection(RotationDirection DirectionEnum)

        {
            switch (DirectionEnum)
            {
                case RotationDirection.CUSTOM:
                    //return related vector
                    return new Vector2(0, 1);

                case RotationDirection.UP:
                    //return related vector
                    return new Vector2(0, 1);

                case RotationDirection.UPRIGHT:
                    //return related vector
                    return new Vector2(0.5f, 0.5f);

                case RotationDirection.RIGHT:
                    //return related vector
                    return new Vector2(1, 0);

                case RotationDirection.DOWNRIGHT:
                    //return related vector
                    return new Vector2(0.5f, -0.5f);

                case RotationDirection.DOWN:
                    //return related vector
                    return new Vector2(0, -1);

                case RotationDirection.DOWNLEFT:
                    //return related vector
                    return new Vector2(-0.5f, -0.5f);

                case RotationDirection.LEFT:
                    //return related vector
                    return new Vector2(-1, 0);

                case RotationDirection.UPLEFT:
                    //return related vector
                    return new Vector2(-0.5f, 0.5f);
            }
            return new Vector2(0, 0);


        }
        //public float ComponetCustomLerpX(float percentTimesMulti )
        //{
        //    float X;
        //    if (ShouldLerpUnclamped)
        //    {
        //         X = (float)Mathf.LerpUnclamped(StartVector.x, EndVector.x, percentTimesMulti);
        //    }else
        //        X = (float)Mathf.Lerp(StartVector.x, EndVector.x, percentTimesMulti);

        //    return X;
        //}
        //public float ComponetCustomLerpY(float percentTimesMulti)
        //{
        //    float Y;
        //    if (ShouldLerpUnclamped)
        //    {
        //        //X
        //        Y = (float)Mathf.LerpUnclamped(StartVector.y, EndVector.y, percentTimesMulti);
        //    }else
        //    Y = (float)Mathf.Lerp(StartVector.y, EndVector.y, percentTimesMulti);

        //    return Y;
        //}





        // ___________________________The Lerp________________________________
        //                            Lerp Normal
        // __________________________________________________________________________________________
        public void LerpClamped(float percent, Vector2 CustomTransCompMulti, ref Vector3 position)
        {

            ////X
            //float X = (float)Mathf.Lerp(StartVector.x, EndVector.x, percent * ((CustomTransCompMulti.x != 0) ? CustomTransCompMulti.x : xMultiplier));
            ////Y
            //float Y = (float)Mathf.Lerp(StartVector.y, EndVector.y, percent * ((CustomTransCompMulti.y != 0) ? CustomTransCompMulti.y : yMultiplier));

            //return new Vector3(X, Y, 0f);



            if (lerpTransDatas[SequentialLerp.rangeIndex].Timed)
            {
                Debug.Log("TimeComp " + OverallTimeComplete);

                {
                    //LERP TIMED
                    float time = TimeBasedCalculateJourneyTime();
                    //X
                    float X = (float)Mathf.Lerp(lerpTransDatas[SequentialLerp.rangeIndex].StartVector.x, lerpTransDatas[SequentialLerp.rangeIndex].EndVector.x, ((CustomTransCompMulti.x != 0) ? TimeBasedCalculateJourneyTime() * CustomTransCompMulti.x : GetMultiplierX(TimeBasedCalculateJourneyTime())));
                    //Y
                    float Y = (float)Mathf.Lerp(lerpTransDatas[SequentialLerp.rangeIndex].StartVector.y, lerpTransDatas[SequentialLerp.rangeIndex].EndVector.y, ((CustomTransCompMulti.y != 0) ? TimeBasedCalculateJourneyTime() * CustomTransCompMulti.y : GetMultiplierY(TimeBasedCalculateJourneyTime())));

                    position = new Vector3(X, Y, 0f);

                }
            }
            else
            {
                //LERP PERCENT
                float X = (float)Mathf.Lerp(lerpTransDatas[SequentialLerp.rangeIndex].StartVector.x, lerpTransDatas[SequentialLerp.rangeIndex].EndVector.x, lerpTransDatas[SequentialLerp.rangeIndex].animationCurveX.Evaluate(SequentialLerp.GetZeroToOneLerpValueFromMainLerpValue(percent)) * ((CustomTransCompMulti.y != 0) ? CustomTransCompMulti.y : lerpTransDatas[SequentialLerp.rangeIndex].yMultiplier));

                //Y
                float Y = (float)Mathf.Lerp(lerpTransDatas[SequentialLerp.rangeIndex].StartVector.y, lerpTransDatas[SequentialLerp.rangeIndex].EndVector.y, lerpTransDatas[SequentialLerp.rangeIndex].animationCurveX.Evaluate(SequentialLerp.GetZeroToOneLerpValueFromMainLerpValue(percent)) * ((CustomTransCompMulti.y != 0) ? CustomTransCompMulti.y : lerpTransDatas[SequentialLerp.rangeIndex].yMultiplier));


                position = new Vector3(X, Y, 0f);

            }
        }

        public void StartFinished(bool Start)
        {
            if (!Start)
            {

            }
            if (Start)
            {
                AssignDirection();
                SetStartTime();
                ConfigureOverallTime();
                EndPos();
            }
        }
       
        public float GetMultiplierX(float percent)
        {
            switch (lerpTransDatas[SequentialLerp.rangeIndex].multiplierTypeX)
            {
                case MultiplierType.NONE:
                    return percent;

                case MultiplierType.SCALER:
                    return percent * lerpTransDatas[SequentialLerp.rangeIndex].xMultiplier;

                case MultiplierType.ANIMATIONCURVE:
                    return lerpTransDatas[SequentialLerp.rangeIndex].animationCurveX.Evaluate(percent);


            }
            return percent;



        }
        public float GetMultiplierY(float percent)
        {
            switch (lerpTransDatas[SequentialLerp.rangeIndex].multiplierTypeY)
            {
                case MultiplierType.NONE:
                    return percent;

                case MultiplierType.SCALER:
                    return percent * lerpTransDatas[SequentialLerp.rangeIndex].xMultiplier;

                case MultiplierType.ANIMATIONCURVE:
                    return lerpTransDatas[SequentialLerp.rangeIndex].animationCurveX.Evaluate(percent);


            }
            return percent;



        }
        public void ReturnPosition(bool isMainLerpEnd)
        {
            if (posReturn != PosReturn.DONTRETURNPOS)
            {
                if (isMainLerpEnd && posReturn == PosReturn.RETURNONMAINCOMPLETE)
                {
                    lerpTransDatas[SequentialLerp.rangeIndex].TransformToMove = FinishedPos;
                }
                else if (!isMainLerpEnd && posReturn == PosReturn.RETURNONTHISCOMPLETE)
                {
                    lerpTransDatas[SequentialLerp.rangeIndex].TransformToMove = FinishedPos;
                }
                // shapeRenderer = (colorReturn == ColorReturn.RETURNONTHISCOMPLETE)? myColorOld :
            }

        }
        public void EndPos()
        {
            switch (whichPosEnd)
            {
                case WhichPosEnd.MYPOSPRIOR:
                    FinishedPos = PriorPos;
                    break;
                case WhichPosEnd.DEFAULTCOLOR:
                    FinishedPos = DefaultPos;
                    break;
                case WhichPosEnd.STARTPOS:
                    FinishedPos = lerpTransDatas[0].StartVector;
                    break;
                case WhichPosEnd.ENDPOS:
                    FinishedPos = lerpTransDatas[lerpTransDatas.Count -1].EndVector;
                    break;
                default:
                    break;
            }

        }

        public void UseCurrentPosCheck()
        {
            //this probs should be a ref to the component pos
            //PriorPos = TransformToMove;

            //StartVector = (StartCurrentPos) ? shapeRenderer.Color : myColorStart;
            //EndVector = (EndCurrentPos) ? shapeRenderer.Color : myColorEnd;
        }
    }
}

