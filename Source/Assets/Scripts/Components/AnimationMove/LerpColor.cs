using Shapes;
using System;
using UnityEngine;

[Serializable]
public class LerpColor
{
    [SerializeField]
    public ShapeRenderer shapeRenderer;

    [SerializeField]
    [Range(0f, 1f)]
    float LerpTime;
    public enum lerpType
    {
        SIMPLETWOCOLORS, GRADIENT
    }
   

    public enum MultiplierType
    {
        NONE, SCALER, ANIMATIONCURVE
    }
    [SerializeField]
    private MultiplierType multiplierType;
    [SerializeField]
    AnimationCurve animationCurve;
    [SerializeField]
    [Range(0f, 2f)]
    float LerpMultiplier = 1f;


    [SerializeField]
    Gradient colorGradient;

    public enum ColorReturn
    {
        DONTRETURNCOLOR, RETURNONTHISCOMPLETE, RETURNONMAINCOMPLETE

    }
    public enum WhichColorEnd
    {
        MYCOLORPRIOR, DEFAULTCOLOR, STARTCOLOR, ENDCOLOR
    }
    [SerializeField]
    private WhichColorEnd whichColorEnd;
    [SerializeField]
    public ColorReturn colorReturn = ColorReturn.RETURNONMAINCOMPLETE;
    public bool StartCurrentColor;
    public bool EndCurrentColor;
    public lerpType type;

    [SerializeField]
    private float TimedDuration = 1.0f;
    private float startTime;


    [SerializeField]
    Color myColor;


    [SerializeField]
    Color myColorStart;

    [SerializeField]
    Color myColorEnd;
    //our color before change
    [SerializeField]
    Color myColorPrior;

    [SerializeField]
    Color DefaultColor;

    [SerializeField]
    Color FinishedColor;

    [SerializeField]
    public bool Active;

    [SerializeField]
    private bool Timed;

    private bool TimeComplete;
    private float fracComplete;

    

    public void LerpColorNow(float percent)
    {

        if (Active)
        {

        
        if (type == lerpType.SIMPLETWOCOLORS)

            LerpBetweenTwo(percent);
        else
            LerpGradient(percent);
        }
    }

    public void LerpGradient(float percent)
    {
        if (Timed)
        {
            Debug.Log("TimeComp " + TimeComplete);

            if (TimeComplete)
            {

                ReturnColor(false);

            }
            else
            {
                shapeRenderer.Color = colorGradient.Evaluate(GetMultiplier(TimeBasedCalculateJourneyTime() ));
            }
        }
        else if (percent != 1f)
        {
            shapeRenderer.Color = colorGradient.Evaluate(GetMultiplier(percent ));
        }//THIS TELLS THE RETURN FUNCTION THAT LERP HAS FINISHED PASSING A BOOL TO TELL ITS NOT THE MAIN ANIMATION COMPONENT LERP THATS COMPLETE BUT This instance 
        else ReturnColor(false);


    }


    public void LerpBetweenTwo(float percent)
    {

        if (Timed)
        {
            Debug.Log("TimeComp " + TimeComplete);

            if (TimeComplete)
            {

                ReturnColor(false);

            }
            else
            {
                shapeRenderer.Color = Color.Lerp(myColorStart, myColorEnd, GetMultiplier(TimeBasedCalculateJourneyTime()));
            }
        }
        else if (percent != 1f)
        {
            shapeRenderer.Color = Color.LerpUnclamped(myColorStart, myColorEnd, GetMultiplier(percent));
        }//THIS TELLS THE RETURN FUNCTION THAT LERP HAS FINISHED PASSING A BOOL TO TELL ITS NOT THE MAIN ANIMATION COMPONENT LERP THATS COMPLETE BUT This instance 
        else ReturnColor(false);


    }
    public void SetStartTime()
    {

        startTime = Time.time;
    }
    public float TimeBasedCalculateJourneyTime()
    {
        fracComplete = (Time.time - startTime) / TimedDuration;
        if (fracComplete >= 1f)
        {
            TimeComplete = true;
        }
        return fracComplete;
    }

    public void StartFinished(bool Start)
    {

        if (!Start)
        {
            //reset completed
            TimeComplete = false;
            ReturnColor(true);
            //main return color
            //TransformToRotate = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        }
        if (Start)
        {
            UseCurrentColorCheck();
            SetStartTime();
            //can be moved to start of aplication unless you want the component to be more dynamic
            EndColor();
        }
    }


    //!!!!!!!!!!!!!!!!use current color as starter or ender!!!!!!!!!!!!!!!!!!!!!!!
    public void UseCurrentColorCheck()
    {
        myColorPrior = shapeRenderer.Color;
        myColorStart = (StartCurrentColor) ? shapeRenderer.Color : myColorStart;
        myColorEnd = (EndCurrentColor) ? shapeRenderer.Color : myColorEnd;
    }
    public void ReturnColor(bool isMainLerpEnd)
    {
        if (colorReturn != ColorReturn.DONTRETURNCOLOR)
        {
            if (isMainLerpEnd && colorReturn == ColorReturn.RETURNONMAINCOMPLETE)
            {
                shapeRenderer.Color = FinishedColor;
            }
            else if (!isMainLerpEnd && colorReturn == ColorReturn.RETURNONTHISCOMPLETE)
            {
                shapeRenderer.Color = FinishedColor;
            }
            // shapeRenderer = (colorReturn == ColorReturn.RETURNONTHISCOMPLETE)? myColorOld :
        }

    }
    public void EndColor()
    {
        switch (whichColorEnd)
        {
            case WhichColorEnd.MYCOLORPRIOR:
                FinishedColor = myColorPrior;
                break;
            case WhichColorEnd.DEFAULTCOLOR:
                FinishedColor = DefaultColor;
                break;
            case WhichColorEnd.STARTCOLOR:
                FinishedColor = myColorStart;
                break;
            case WhichColorEnd.ENDCOLOR:
                FinishedColor = myColorEnd;
                break;

        }

    }
    public float GetMultiplier( float percent)
    {
        switch (multiplierType)
        {
            case MultiplierType.NONE:
                return percent;

            case MultiplierType.SCALER:
                return percent * LerpMultiplier;

            case MultiplierType.ANIMATIONCURVE:
                return animationCurve.Evaluate(percent);


        }
        return percent;



    }
}
