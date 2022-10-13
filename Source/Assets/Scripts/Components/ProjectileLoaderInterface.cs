using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimationLibrary;
public class ProjectileLoaderInterface : MonoBehaviour
{

    public List<ToOrbitTest> orbitObjects;
    public int CurrentObject;
    public bool test;
    private bool left = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ConfigureDirection(bool start, bool left)
    {

        orbitObjects[CurrentObject].LerpOrbitConfigure(start,left);
        CurrentObject += 1;
    }
    // Update is called once per frame
    void Update()
    {
        //if (test)
        //{
        //    left = !left;
        //    orbitObjects[CurrentObject].LerpOrbitConfigure(true, left);
            
        //    test = false;
        //}
    }
}
