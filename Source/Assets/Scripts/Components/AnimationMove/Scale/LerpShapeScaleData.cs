using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  using System;

namespace AnimationLibrary
{

    public enum ScaleShapeLerpType
    {
        LERP,LERPUNCLAMPED, LERPANGLE
    }
    [Serializable]
    public class LerpShapeScaleData 
    {

        [SerializeField]
        public ScaleShapeLerpType thisScaleLerpType;
        public float ShapeCurrentScale;
        //  [SerializeField]
        //public bool XScale, YScale, ZScale;
        //Object scale 
        //Skew scale

        [SerializeField]
        public bool Timed;

        public AnimationCurve animationCurve;

        [SerializeField]
        public float TimedDuration = 1.0f;

        [SerializeField]
        public float StartSize;
        [SerializeField]
        public float EndSize;

        [SerializeField]
        [Range(0f, 20f)]
        public float xMultiplier = 1f;
        [SerializeField]
        [Range(0f, 20f)]
        public float yMultiplier = 1f;
        [SerializeField]
        public bool Active;


    }
}