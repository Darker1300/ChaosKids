using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlingMain : MonoBehaviour
{

    public struct TouchDrag
    {
        public TouchDrag(int id)
        {
            _id = id;
            StartVector = Vector3.zero;
            EndVector = Vector3.zero;
            hasStart = false;
            DragVector = Vector3.zero;
            lockedVector = false;

        }
        public int _id;

        public Vector3 StartVector;
        public Vector3 EndVector;
        public bool hasStart;
        public Vector3 DragVector;
        public bool lockedVector;
        public void ZeroVals()
        {
            StartVector = Vector3.zero;
            EndVector = Vector3.zero;
            hasStart = false;
            DragVector = Vector3.zero;
            lockedVector = false;
        }
        public void UpdateDrag()
        {
            if (hasStart && !lockedVector)
                DragVector = (Vector2)Camera.main.ScreenToWorldPoint(EndVector) - (Vector2)Camera.main.ScreenToWorldPoint(StartVector);
           // Debug.Log("TimeAngle " + Vector3.SignedAngle(Vector3.up, DragVector, Vector3.forward));
        }

        public bool CheckToLockMagnitude(float Mag)
        {
            if (DragVector.magnitude >= Mag)
            {
                DragVector = DragVector.normalized;
                lockedVector = true;
                return true;
            }
            else return false;
        }

        public bool Compare(TouchDrag ToCompare)
        {
            if (ToCompare._id == _id)
            {
                return true;
            }
            else return false;

        }




    }
    //EVENTS
    public delegate void SlingDragUpdate(Vector2 mouseDragDirection);
    public event SlingDragUpdate OnCharging;

   
    //public delegate void SlingRelease(Vector2 mouseDragDirection);
    //public event SlingRelease OnSlingRelease;


    public UnityEvent<bool> SlingStart;

    public UnityEvent<bool> SlingEnd;
    public UnityEvent<Vector2> SlingEndVector;

    //public delegate void SlingStart();
    //public event SlingStart OnSlingStart;

    //TOUCH
    private TouchDrag TouchLeftDrag = new TouchDrag(1);

    private TouchDrag TouchLeftProjectileStart = new TouchDrag(2);
    private TouchDrag TouchRightDrag = new TouchDrag(3);
    private TouchDrag TouchRightProjectileStart = new TouchDrag(4);



    //TOUCH BOOLS
    public bool RightMouseDown = false;
    public bool RightMouseDownRelease = false;
    private Vector2 StartRightMouseScreenPos;
    public bool LeftMouseDown = false;
    public bool LeftMouseDownRelease = false;


    //TOUCH POSITIONS
    public Vector2 StartMouseScreenPos;
    public Vector2 StartMouseWorldPos;

    public Vector2 ScreenMousePos;
    private Vector2 ScreenRightMousePos;
    private Vector3 worldRightMousePos;
    private Vector2 updatedDragRightScreenVector;
    public Vector2 worldMousePos;


    //dont really need below 
    public Vector2 UpdatedSlingDirection;
    public Vector2 updatedDragWorldVector;
    public Vector2 updatedDragScreenVector;

    public float dragAngle;

    // Start is called before the first frame update
    void Start()
    {
        //InputManager.OnMouseLeftDownRelease += ReleaseShot;

        //InputManager.OnMouseLeftDownStart += OnLeftDown;
        //InputManager.OnMouseLeftDownRelease += OnLeftDownRelease;
        //// InputManager.OnMouseLeftDownRelease +=  =>{GetComponent<PlaySound>().PlayAudioClipOneShot() };
        //InputManager.OnMouseRightDownStart += OnRightDown;
        //InputManager.OnMouseRightDownRelease += OnRightDownRelease;
        //InputManager.OnGetMousePosition += UpdateMousePos;

        /////only for mobile
        //InputManager.OnGetTouchRightPos += UpdateRightTouchPos;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnLeftDown(Vector2 screenMousePos)
    {
        Debug.Log("leftStstarted");
        SlingStart?.Invoke(true);
        //needs to be screenpos because if it is world vector it will go off screen
        TouchLeftDrag.StartVector = screenMousePos;
        TouchLeftDrag.hasStart = true;
        LeftMouseDown = true;
        //TouchLeftDrag.UpdateDrag();
       
    }
    //private void OnRightDown(Vector2 screenMousePos)
    //{

    //    RightMouseDown = true;
    //    if (InputManager.Instance.Mobile)
    //    {
    //        TouchRightDrag.StartVector = screenMousePos;
    //        TouchRightDrag.hasStart = true;

    //    }

    //    TouchLeftDrag.StartVector = TouchLeftDrag.EndVector;
    //    TouchLeftDrag.hasStart = true;




    //}
    //private void OnLeftDownRelease(Vector2 screenMousePos)
    //{
    //    SlingEnd?.Invoke(false);
    //    TouchLeftDrag.hasStart = false;
    //    SlingEndVector?.Invoke(updatedDragWorldVector);
    //}


    //private void OnRightDownRelease(Vector2 screenMousePos)
    //{
    //    RightMouseDown = false;
    //    if (InputManager.Instance.Mobile)
    //        TouchRightDrag.hasStart = false;
    //    SlingEndVector?.Invoke(updatedDragWorldVector);
    //    //TwoFingerDrawBackStartEndEvent?.Invoke(false);
    //    //EventStartedFired = false;
    //}
    public void UpdateMousePos(Vector2 screenMousePos)
    {

        //this is needs to be world points 
        //ScreenMousePos = screenMousePos;
        TouchLeftDrag.EndVector = screenMousePos;
        TouchLeftDrag.UpdateDrag();
        updatedDragWorldVector = TouchLeftDrag.DragVector;
        Debug.DrawLine(transform.position, transform.position + TouchLeftDrag.DragVector);


    }


    public void UpdateRightTouchPos(Vector2 screenMousePos)
    {
        //this wont be called be subscribed if input manager mobile is not true   
        TouchRightDrag.EndVector = screenMousePos;

        TouchRightDrag.UpdateDrag();

    }
    public void ReleaseShot(Vector2 release)
    {
        LeftMouseDown = false;
        //leftDragStartLine.End = Vector3.zero;
        StartMouseScreenPos = Vector2.zero;
        StartMouseWorldPos = Vector2.zero;
        UpdatedSlingDirection = Vector2.zero;
        TouchLeftDrag.DragVector = Vector2.zero;
        worldMousePos = Vector2.zero;
    }
}
