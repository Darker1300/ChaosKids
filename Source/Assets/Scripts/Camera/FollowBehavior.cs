using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehavior : MonoBehaviour
{
    [SerializeField]
    protected float followSpeed;

    [SerializeField]
    protected Transform trackingTarget;
    [SerializeField]
    float xOffset;
    [SerializeField]
    float yOffset;

    [SerializeField]
    protected bool isYlocked = false;
    [SerializeField]
    protected bool isXlocked = false;
    public bool trackObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trackObject)
        {
            float xTarget = trackingTarget.position.x;
            float yTarget = trackingTarget.position.y;

            float xNew = transform.position.x;

            if (!isXlocked)
            {
                xNew = Mathf.Lerp(transform.position.x, xTarget, followSpeed * Time.deltaTime);

            }



            float yNew = transform.position.y;
            if (!isYlocked)
            {
                yNew = Mathf.Lerp(transform.position.y, yTarget, followSpeed * Time.deltaTime);


            }

            transform.position = new Vector3(xNew, yNew, transform.position.z);



        }


        //transform.position = new Vector3(trackingTarget.position.x +xOffset, trackingTarget.position.y + yOffset, transform.position.z);

    }
}
