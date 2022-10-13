using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragConverter 
{

    public Vector3 GetDragVectorScreen(Vector2 start, Vector2 end)
    {

        return   start - end;
    
    }
    public Vector3 GetDragVectorWorld(Vector2 start, Vector2 end)
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(end) - (Vector2)Camera.main.ScreenToWorldPoint(start) ;
        //return Camera.main.ScreenToWorldPoint(start) - Camera.main.ScreenToWorldPoint(end);


    }
    public Vector3 GetDragAngle(Vector2 start, Vector2 end)
    {

        return start - end;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
