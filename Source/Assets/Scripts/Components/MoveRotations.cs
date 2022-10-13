using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotations : MonoBehaviour
{
    [System.Serializable]
    public struct LerpRotation
    {

        [Header("Animation Name")]
        [SerializeField]
        private string name;
        [Header("Animation Object")]
        [SerializeField]
        Transform TransformToRotate;

        [Header("Move Transforms locally?")]
        [SerializeField]
        public bool RotateLocally;

        [Header("LerpUnclamped?")]
        [SerializeField]
        public bool ShouldLerpUnclamped;

        [Header("Should Animation be used")]
        [SerializeField]
        public bool Active;

        [Header("T Multiplication")]
        [SerializeField]
        [Range(0f, 2f)]
        public float xMultiplier;
        public float yMultiplier;

        [Header("startVariables")]
        [SerializeField]
        private Vector2 StartVector;


        [Header("EndVariables")]
        [SerializeField]
        private Vector2 EndVector;


        public void MoveTransform(float percent)
        {

            if (ShouldLerpUnclamped)
                LerpUnclamped(percent);
            else LerpClamped(percent);

        }





        // ___________________________The Lerp________________________________
        //                            Lerp Unclamped
        // __________________________________________________________________________________________
        public void LerpUnclamped(float percent)
        {
            //X
            float X = (float)Mathf.LerpUnclamped(StartVector.x, EndVector.x, percent * xMultiplier);
            //Y
            float Y = (float)Mathf.LerpUnclamped(StartVector.y, EndVector.y, percent * yMultiplier);

            // ___________________________Move Locally?________________________________

            //move locally
            if (RotateLocally)
            {
                TransformToRotate.localPosition = new Vector3(X, Y, 0f);
            }
            else //move worldspace
                TransformToRotate.position = new Vector3(X, Y, 0);
        }
        // ___________________________The Lerp________________________________
        //                            Lerp Normal
        // __________________________________________________________________________________________
        public void LerpClamped(float percent)
        {
            //X
            float X = (float)Mathf.Lerp(StartVector.x, EndVector.x, percent * xMultiplier);
            //Y
            float Y = (float)Mathf.Lerp(StartVector.y, EndVector.y, percent * yMultiplier);

            // ___________________________Move Locally?________________________________
            //move locally
            if (RotateLocally)
            {
                TransformToRotate.localPosition = new Vector3(X, Y, 0f);

            }
            else //move worldspace
                TransformToRotate.position = new Vector3(X, Y, 0);
        }
    }


    

    //[SerializeField]
    //public List<LerpPosition> LerpList = new List<LerpPosition>();

    //WingRightLocal.localRotation = Quaternion.LookRotation(Vector3.forward, (Vector3) Vector2.Lerp(new Vector2(0.95f, -0.05f), new Vector2(-0.5f, 0.5f), percentOfMaxDrawOne));


    // Start is called before the first frame update
    void Start()
    {




    }
    //public void Lerp(float percent)
    //{

    //    Debug.Log(" lerping" + percent);
    //    if (LerpList.Count != 0)
    //    {
    //        foreach (LerpPosition position in LerpList)
    //            position.MoveTransform(percent);
    //    }

    //}
    // Update is called once per frame
    void Update()
    {

    }
}
