using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryController : MonoBehaviour
{
    // Start is called before the first frame update
    NewTrajectoryCalculator trajectoryCalculator;
    //BasePlayerController playerController;
    [Header("Jump Sling Variables")]
    


    [SerializeField]
    int levelsOfCharge;
    [SerializeField]
    float maxMagnitude;

    float chargePercent;
    int currentLvlOfCharge;
    public int ChargeCurrentLevel;

    //Screenspace magnitude max
    [SerializeField]
    //for converting our screenspace into a managable value
    float screenSpaceMagMax;


    //to reference current magnitude level
    [SerializeField]
    private int sizeOfList = 0;
    

    void Start()
    {
        chargePercent = maxMagnitude / levelsOfCharge;

        
        trajectoryCalculator = GetComponent<NewTrajectoryCalculator>();
        //playerController = GetComponent<BasePlayerController>();
        //playerController.OnCharging += UpdateTrajectory;

        //playerController.OnChargeStart += ChargeStarted;
        //playerController.OnChargeRelease += ChargeEnded;

    }

    void OnEnable()
    {
       
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="DragWorldSpaceVector"></param>
    public void UpdateTrajectory(Vector2 DragWorldSpaceVector)
    {

        //convert Screen Space magnitude to a magnitude useful for 
        
        Vector2 trueSling =  DragWorldSpaceVector;
        float currenMag = DragWorldSpaceVector.magnitude;


        //Debug.Log(currenMag);
        //eqaul to zero up top so we dont have to reset it and if nothing changes it bellow the it will
        //currentChargeMagnitude = 0.0f;
        //gets the current charge index
        int chargeIndex = GetChargeLevel(currenMag);
       // Debug.Log("mouse Magnitude = " + currenMag);
        trajectoryCalculator.velocity = trueSling *2.0f ;


        //trajectoryCalculator.velocity = Vector2.ClampMagnitude( trueSling , maxMagnitude);

        //if (chargeIndex != 0 && chargeIndex != ChargeCurrentLevel)
        //{

        //    // Debug.Log("changed ");
        //    ChargeCurrentLevel = chargeIndex;
        //    //Debug.DrawLine(transform.position,new Vector2(transform.position.x + trajectoryCalculator.velocity.x, transform.position.y + trajectoryCalculator.velocity.y) );
        //    //currentChargeMagnitude = trueSlingVect.magnitude / 10;
        //}
        ////if it is a level update trajectory vector clamp it to our current 
        //if (chargeIndex!=0)
        //    //we need to update our current trajectory calculator velocity but simply limit it to our current lvl
        //    trajectoryCalculator.velocity = -DragWorldSpaceVector;
        //    //trajectoryCalculator.velocity = Vector2.ClampMagnitude(-DragWorldSpaceVector, ChargeCurrentLevel * chargePercent);

        ////Vector2 trueSlingVect = Vector2.ClampMagnitude(-DragScreenSpaceVector, maxMagnitude);
        ////Debug.Log(DragScreenSpaceVector.magnitude);

        ////this simply updates our magnitude charge level

    }


    // Update is called once per frame
    void Update()
    {

    }
    public void ChargeStarted()
    {
        trajectoryCalculator.line.enabled = true;
    }
    public void ChargeEnded(Vector2 thisDoesntNeedVect)
    {
        trajectoryCalculator.line.enabled = false;

    }
    //if it is a new charge return motherfucker the level of charge
    int GetChargeLevel(float magnitude)
    {
        //check if there is a next in in list first 
        if ((magnitude % chargePercent) == 0 )
        {
            return (int)(magnitude / chargePercent);
        }
       else return 0;

    }
    
}
