using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AnimationLibrary
{
    public enum OrbitType
    {
       NORMAL,SPIRAL    
    }

    [Serializable]
    public class OrbitData 
    {
        [Header("Animation Name")]
        [SerializeField]
        private string name;

        public OurLerpType thisRotationLerpType;
        public RotationDirection StartDirection;
        public RotationDirection EndDirection;
        [SerializeField]
        public OrbitType thisOrbitType;
        [Header("Animation Object")]
        public Vector3 TransformOrbitPos;
        [SerializeField]
       
        public bool StartFromCentre;
        public bool TakeX = false;


        

        [SerializeField]
        public bool Timed;

        public AnimationCurve animationCurve;

        [SerializeField]
        public float TimedDuration = 1.0f;



        [SerializeField]
        public Vector3 StartVector;


        [SerializeField]
        public Vector3 EndVector;

        public Vector3 center;
        public Vector3 StartRelCenter;
        public Vector3 EndRelCenter;

        [SerializeField]
        [Range(0f, 20f)]
        public float StartMultiplier = 1f;
        [SerializeField]
        [Range(0f, 20f)]
        public float EndMultiplier = 1f;


        [SerializeField]
        public bool Active;


        [SerializeField]
        [Range(0f, 2f)]
        public float OrbitMultiplier;
    }
}
