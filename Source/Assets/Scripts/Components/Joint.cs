using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(DistanceJoint2D))]
public class Joint : MonoBehaviour
{

    public GameObject body;
    public Vector3 target;
    public DistanceJoint2D joint2D;
    // Start is called before the first frame update


    void Start()
    {
        //joint2D = GetComponent<DistanceJoint2D>();
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
