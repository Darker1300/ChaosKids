using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Shapes;
namespace AnimationLibrary
{ 
[Serializable]
public class TransformComponent 
{
    public LerpColor lerpColor;
    public enum invert
    {
        INVERTX, INVERTY, INVERTBOTH
    }
    public enum customMultiplier
    {
        NONE, MULTIPLIERX, MULTIPLIERY, BOTH
    }
    public customMultiplier MultiplierIdentity;
    public invert transformEnum;
    public invert RotationEnum;
    public Transform thisTransform;
    public ConfigureShape ShapeScale;

    public bool TransformInvertX;
    public bool TransformInvertY;
    public bool RotationInvertX;
    public bool RotationInvertY;
    public bool ApplyRotation;
    public bool ApplyTransform;
    public bool ApplyOrbit;
    public bool ApplyScale;

    [SerializeField]
    [Range(0f, 2f)]
    private float txSpeed = 1;
    [Range(0f, 2f)]
    private float tySpeed = 1;
    private float RSpeed = 1;
    public Vector2 multipliers;
    public bool hasShapeComponent;
        public bool ApplyShapeScale;

    // Start is called before the first frame update
    //void Start()
    //{
    //    multipliers = new Vector2( txSpeed,tySpeed );
    //}

        //// Update is called once per frame
        //void Update()
        //{



        //}



        public void ConfigurRotation(Quaternion rotation)
    {
        thisTransform.localRotation = rotation;
        //switch (RotationEnum)
        //{
        //    case invert.INVERTBOTH:

        //        break;

        //    case invert.INVERTX:

        //        break;

        //    case invert.INVERTY:

        //        break;

        //}

    }
    public void ConfigurTransforms(Vector3 transform)
    {
        switch (transformEnum)
        {
            case invert.INVERTBOTH:
                thisTransform.localPosition = new Vector3(-transform.x, -transform.y, 0);
                break;

            case invert.INVERTX:
                thisTransform.localPosition = new Vector3(-transform.x, transform.y, 0);
                break;

            case invert.INVERTY:
                thisTransform.localPosition = new Vector3(transform.x, -transform.y, 0);
                break;

        }



        //public void CheckMultipliers(float x,float y)
        //{
        //    if (x != txSpeed && y != tySpeed)
        //    {
        //        MultiplierIdentity = customMultiplier.NONE;
        //    } else
        //    { 




        //    }
        //        MultiplierIdentity = (x!= txSpeed && y!= tySpeed)? customMultiplier.NONE
        //}

    }

    public void ConfigurOrbit(Vector3 orbitPos)
    {
        thisTransform.localPosition = orbitPos;
        //switch (RotationEnum)
        //{
        //    case invert.INVERTBOTH:

        //        break;

        //    case invert.INVERTX:

        //        break;

        //    case invert.INVERTY:

        //        break;

        //}

    }

    public void ConfigurOjectScaleScale(Vector3 scale)
    {
        thisTransform.localScale = scale;
        //switch (RotationEnum)
        //{
        //    case invert.INVERTBOTH:

        //        break;

        //    case invert.INVERTX:

        //        break;

        //    case invert.INVERTY:

        //        break;

        //}

    }
    public void GetShapeComponent()
    {
        lerpColor.shapeRenderer = thisTransform.GetComponent<Shapes.ShapeRenderer>();
    }
    public void StartComponents(bool start)
    {
        if (start)
        {
            lerpColor.StartFinished(true);
        }else 
            lerpColor.StartFinished(false);
    
    }
    ///go through vertexes if they are not 0 then cache the original size and times each verticies original size with our scaler 
    public void ConfigurShapeScale(float scaleFactor)
    {
            ShapeScale.ScaleShape(scaleFactor);

    }


   
}

}