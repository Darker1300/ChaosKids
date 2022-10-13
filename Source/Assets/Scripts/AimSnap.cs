using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSnap : MonoBehaviour
{
    //private BasePlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        //controller = GetComponent<BasePlayerController>();
        //controller.OnChargingProjectileEvent += PlotAroundCircle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlotAroundCircle(Vector3 aimDirection)
    {
        
        Debug.DrawLine(transform.position, transform.position + (Vector3)aimDirection, Color.blue);
       
        
    }
}
