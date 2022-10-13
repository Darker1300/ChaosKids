using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace AnimationLibrary
{
    [Serializable]
    public class RotationData 
    {
        

        //public int lerpIndexer = 0;
        //Start is called before the first frame update

        /// ///////////////////////////////////////////////////////////////////




        [SerializeField]
        public float fullRotations;
        [SerializeField]
        public bool allowChooseShortestPath;

        // looping in a direction 
        [SerializeField]
        private bool loop;
        /////////////////////////////////////////////////////////////////////////////
        [SerializeField]
        public int RotationAmount;
        public bool RotateForward;
        //public int RotationsMain;
        //public bool forward;
        public enum TypeMovement
        {
            PINGPONG, REOCCURING
        }



        public TypeMovement mainRotate;
        public TypeMovement backRotate;

        public AnimationCurve animationCurve;
       

        public float startRotationZ;
        public float endRotationDirectionZ;
        public float angle;
        public float endRotationZ;


        /////////////////////////////////////////////////////////////////////////////
        //loop rotation
        /// <summary>
        /// loop ping pong
        /// loop rotation direction which is hey just start rotating in this direction i dont care how many times it does it (keeptrack of it tho may want it for cancel)
        /// loop rotation as in rotate and finish here snap to start do it again
        /// 
        /// </summary>

        //calculate journey over duration /time
        //
        //

        //

        // Start is called before the first frame update
        //NAME
        [Header("Animation Name")]
        [SerializeField]
        private string name;
        [SerializeField]
        public OurLerpType thisRotationLerpType;
        [SerializeField]
        public RotationDirection StartDirection;
        [SerializeField]
        public RotationDirection EndDirection;

        [Header("Animation Object")]
        public Transform TransformToRotate;


        [SerializeField]
        public bool Timed;


        [SerializeField]
        public float TimedDuration = 1.0f;


        [SerializeField]
        public Vector3 StartVector;


        [SerializeField]
        public Vector3 EndVector;

        public Quaternion EndRotation;
        public Quaternion StartRotation;
        public Quaternion currentRotation;

        [Header("Move Transforms locally?")]
        [SerializeField]
        public bool RotateLocally;

        [Header("LerpUnclamped?")]
        [SerializeField]
        public bool ShouldUnclamped;

        [Header("SlerpLerp?")]
        [SerializeField]
        public bool Slerp;


        [SerializeField]
        public bool Active;


        [SerializeField]
        [Range(0f, 2f)]
        public float RotateMultiplier;


        // Time to move from sunrise to sunset position, in seconds.
        // The time at which the animation started.
       
    }
}
