using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AnimationLibrary
{

    [Serializable]
    public class LerpScaleData 
{

        [SerializeField]
        public OurLerpType thisScaleLerpType;
        public Vector3 TransformScale;
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
        public Vector3 StartVector;
        [SerializeField]
        public Vector3 EndVector;

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