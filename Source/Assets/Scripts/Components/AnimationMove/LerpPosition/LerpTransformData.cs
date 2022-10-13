using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace AnimationLibrary
{
    public enum lerpType
    {
        CLAMPED, UNCLAMPED
    }

    public enum WhichPosEnd
    {
        MYPOSPRIOR, DEFAULTCOLOR, STARTPOS, ENDPOS
    }
    public enum PosReturn
    {
        DONTRETURNPOS, RETURNONTHISCOMPLETE, RETURNONMAINCOMPLETE

    }

    public enum MultiplierType
    {
        NONE, SCALER, ANIMATIONCURVE
    }
    [Serializable]
    public class LerpTransformData
    {

        public lerpType type;


        public RotationDirection StartDirection;
        public RotationDirection EndDirection;

        [Header("Animation Name")]
        [SerializeField]
        private string name;
        [Header("Moved Vector")]

        public Vector3 TransformToMove;

        //[Header("startVariables")]
        [SerializeField]
        public Vector2 StartVector;


        //[Header("EndVariables")]
        [SerializeField]
        public Vector2 EndVector;

        [Header("LerpUnclamped?")]
        [SerializeField]
        public bool ShouldLerpUnclamped;


        [SerializeField]
        public bool Active;
        [SerializeField]
        public bool Timed;

        [SerializeField]
        public float startTime;

        [SerializeField]
        public float TimedDuration;
        public float fracComplete;
        public bool TimeComplete;
        [SerializeField]
        [Range(0f, 20f)]
        public float StartMultiplier = 1f;
        [SerializeField]
        [Range(0f, 20f)]
        public float EndMultiplier = 1f;

        [SerializeField]
        [Range(0f, 2f)]
        public float xMultiplier = 1f;
        [SerializeField]
        [Range(0f, 2f)]
        public float yMultiplier = 1f;

        [SerializeField]
        public AnimationCurve animationCurveX;
        [SerializeField]
        public AnimationCurve animationCurveY;

        [SerializeField]
        public MultiplierType multiplierTypeX;
        [SerializeField]
        public MultiplierType multiplierTypeY;


    }
}
