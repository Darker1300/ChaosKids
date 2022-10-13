using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTester : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0f, 1f)]
    public float inputValueTest;
    //this will be ranges between 0 - 1 (for example 0.25,prev 0.35,0.5 )
    public List<float> rangesCurrentMax;
    public float currentIndexDuration;
    public int rangeIndex;

    public float OutputValue;
    ///CHECK VALUE IS STILL IN RANGE , IF SO 
    public void GetZeroToOneLerpValueFromMainLerpValue(ref float PassedInputValue)
    {

        //this takes off the previous range value so this range will value will start at zero 
        float CutValue = PassedInputValue;
         CutValue = (rangeIndex == 0) ? CutValue : CutValue - rangesCurrentMax[rangeIndex -1];

        //IF STILL IN RANGE
        if (CutValue > 0.0f && CutValue < currentIndexDuration)
        {
            Debug.Log("cutVal" + CutValue);
            //PassedInputValue = PassedInputValue / currentIndexDuration;
            OutputValue = CutValue / currentIndexDuration;
        }
        else OutOfCurrentSpotFindAsignCurrentIndex(ref PassedInputValue);
    }

    public bool OutOfCurrentSpotFindAsignCurrentIndex(ref float PassedInputValue)
    {
        //range 0 - our first section end (lets say 0.25f) INDEX ZERO
        if ( PassedInputValue < rangesCurrentMax[0])
        {
            rangeIndex = 0;
            //Range value Inbetween
            currentIndexDuration = rangesCurrentMax[0];
            return true;

        }//make sure we have more than one range
        else if (rangesCurrentMax.Count > 0)
        {
            //rangesCurrentMax.Count
            //for loop to find which range you passed in value lies within
            for (int i = 1; i < rangesCurrentMax.Count; i++)
            {
                if ((i + 1) <= rangesCurrentMax.Count)
                {
                    if (PassedInputValue < rangesCurrentMax[i])
                    {

                        //[DURATION OF THIS RANGE] hey current pos value - previous = our duration of the thing
                        //{----(i-1)--durInbetween-(i)---}
                        currentIndexDuration = rangesCurrentMax[i] - rangesCurrentMax[i - 1];
                        //assignIndex
                        rangeIndex = i;

                        //we are in this range 
                        return true;

                    }
                }
            }

        }
        return false;
    }

    private void Update()
    {
        GetZeroToOneLerpValueFromMainLerpValue(ref inputValueTest);
    }


    private void Start()
    {
        OutOfCurrentSpotFindAsignCurrentIndex(ref  inputValueTest);
    }

}
