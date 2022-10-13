using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCameraDirection : MonoBehaviour
{
    private bool rotateToTarget;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (rotateToTarget == true && target != null)
        //{
        //    print("Rotating towards target");


        //    targetRotation = Quaternion.LookRotation(transform.position - target.normalized, Vector3.forward);
        //    targetRotation.x = 0.0f;//Set to zero because we only care about z axis
        //    targetRotation.y = 0.0f;

        //    player.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);



        //    if (Mathf.Abs(player.transform.rotation.eulerAngles.z - targetRotation.eulerAngles.z) < 1)
        //    {

        //        rotateToTarget = false;
        //        travelToTarget = true;
        //        player.transform.rotation = targetRotation;
        //        print("ROTATION IS DONE!");
        //    }
        //}

    }
}
