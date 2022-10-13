using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.Interactions;

public class TestInputNew : MonoBehaviour
{

    private InputAsset inputAsset;
    //Output Variables

    public Vector2 DragLeftStartScreenPos;
    public Vector2 DragRightStartScreenPos;
    public float LeftStartTime; 
    public float RightStartTime;
    public float TapTime;
 


    private int screenWidth;
    public float minDragAmount;
    //Left Right Vectors


    //---DRAG MOUSE/TOUCH--
    //START POS
    public delegate void StartScreenPos(Vector2 StartScreenPos);
    public event StartScreenPos StartPosEvent;




    //CURRENT DRAG SCREENPOS
    public delegate void DragLeftUpdate(Vector2 currentScreenPosition);
    public event DragLeftUpdate LeftDragVectorEvent;

    public delegate void DragRightUpdate(Vector2 currentScreenPosition);
    public event DragRightUpdate RightDragVectorEvent;

    public delegate void DragLeft(bool state);
    public event DragLeft LeftDragEvent;
    public event DragLeft RightDragEvent;


    //public delegate void DragStart(Vector2 currentScreenPosition);
    //public event DragLeftUpdate LeftDragVectorEvent;

    //public delegate void DragRightUpdate(Vector2 currentScreenPosition);
    //public event DragRightUpdate RightDragVectorEvent;

    //TAP 
    //public delegate void TapLeftPos(Vector2 screenPosition);
    public event EventHandler TapLeftEvent;

    //public delegate void TapRightPos(Vector2 screenPosition);
    public event EventHandler TapRightEvent;

    //public delegate void LeftUp(Vector2 screenPosition, bool State);
    //public event TapLeftPos LeftUpEvent;

    //public delegate void RightUp(Vector2 screenPosition, bool State);
    //public event TapLeftPos RightUpEvent;


    public delegate void TwoFingerTap(bool State);
    public event TwoFingerTap twoFingerTapEvent;

    //SLOW TAPS
    public delegate void SlowTapActivate(bool state);
    public event SlowTapActivate SlowTapLeftEvent;


    public event SlowTapActivate SlowTapRightEvent;
    //two finger drag 

    //



    //--TOUCH MOUSE/TOUCH--
    //tap screen event
    public delegate void TapScreen();
    public event TapScreen TapEvent;

    //Hold Down
    public delegate void HoldStart();//pos
    public event HoldStart HoldDownStartEvent;

    //Hold End
    public delegate void HoldRelease();
    public event HoldRelease HoldDownEndEvent;

    //Hold 




    public void OnEnable()
    {


        screenWidth = Screen.width;


        inputAsset = new InputAsset();
        inputAsset.Player.Enable();
        inputAsset.UI.Disable();


        ////////////////////////////////////////////////////LEFT////////////////////////////////////////////////

        //MOVEMENT BOOST AND sHORT tURN

        //inputAsset.Player.LeftTap.started +=
        //ctx =>
        //{

        //    Debug.Log("click");

        //};
        //inputAsset.Player.LeftClick.started +=
        //ctx =>
        //{
        //    Debug.Log("Down");
        //    if (ctx.interaction is SlowTapInteraction)
        //    {
        //        //if ((Camera.main.ScreenToWorldPoint(DragLeftStartScreenPos) - Camera.main.ScreenToWorldPoint(inputAsset.Player.DragLeft.ReadValue<Vector2>())).magnitude < minDragAmount)
        //        //{



        //        //}

        //        //TRIGGER SLOW TAP IF DRAG MAG Below ThreshHold
        //        //if ((Camera.main.ScreenToWorldPoint(DragLeftStartScreenPos) - Camera.main.ScreenToWorldPoint(inputAsset.Player.DragLeft.ReadValue<Vector2>())).magnitude < minDragAmount)
        //        //{
        //        //    Debug.Log("left SlowStart");
        //        //    slowTap = true;
        //        //    SlowTapLeftEvent?.Invoke(true);

        //        //}
        //        //else if(ctx.interaction is not TapInteraction)
        //        //{
        //        //    LeftDragEvent?.Invoke(true);

        //        //    Debug.Log(" Drag Left Started");
        //        //}
        //        //Drag

        //        // Debug.Log((Camera.main.ScreenToWorldPoint(DragLeftStartScreenPos) - Camera.main.ScreenToWorldPoint(inputAsset.Player.DragLeft.ReadValue<Vector2>())).magnitude);
        //    }
        //};
        ////performed full charge (!have a canceled one to deal )
        //inputAsset.Player.LeftClick.performed +=
        //      ctx =>
        //    {
        //        // get side 
        //        //check if other side is down (Two finger tap)
        //        DragLeftStartScreenPos = Vector2.zero;

        //        //if (ctx.interaction is SlowTapInteraction)
        //        //{
        //        //    //if (slowTap == true)
        //        //    //{
        //        //    //    Debug.Log("Slow left TapFinished");
        //        //    //    SlowTapLeftEvent?.Invoke(false);
        //        //    //    slowTap = false;

        //        //    //}
        //        //    //else if (ctx.interaction is not TapInteraction)
        //        //    //{
        //        //    //    Debug.Log("Drag Left FInished");
        //        //    //    LeftDragEvent?.Invoke(false);

        //        //    //}

        //        //    //Debug.Log("sLowTap" + inputAsset.Player.Drag.ReadValue<Vector2>());


        //        //}
        //        //else
        //        //{
        //        //    Debug.Log("leftTap");

        //        //    TapLeftEvent?.Invoke(null, EventArgs.Empty);


        //        //}


        //    };

        ////////////////////////////////////////////////////RIGHT////////////////////////////////////////////////

        // inputAsset.Player.RightClick.started +=
        //ctx =>
        //{


        //    if (ctx.interaction is SlowTapInteraction)
        //    {
        //        //TRIGGER SLOW TAP IF DRAG MAG Below ThreshHold
        //        //if ((Camera.main.ScreenToWorldPoint(DragRightStartScreenPos) - Camera.main.ScreenToWorldPoint(inputAsset.Player.DragRight.ReadValue<Vector2>())).magnitude < minDragAmount)
        //        //{

        //        //    slowTap = true;
        //        //    SlowTapRightEvent?.Invoke(true);
        //        //    Debug.Log("slow Right tapStart");

        //        //}
        //        //else
        //        //{
        //        //    RightDragEvent?.Invoke(true);

        //        //    Debug.Log("Drag right Event Start");
        //        //    //Drag

        //        //}
        //    }
        //};
        //performed full charge (!have a canceled one to deal )
        //inputAsset.Player.RightClick.performed +=
        //      ctx =>
        //      {
        //          // get side 
        //          //check if other side is down (Two finger tap)

        //          if (ctx.interaction is SlowTapInteraction)
        //          {
        //              if (slowTap == true)
        //              {
        //                  Debug.Log("Slow Tap right finished");
        //                  SlowTapRightEvent?.Invoke(false);
        //                  slowTap = false;

        //              }
        //              else
        //              {
        //                  Debug.Log("drag right finished");
        //                  RightDragEvent?.Invoke(false);

        //              }

        //              //Debug.Log("sLowTap" + inputAsset.Player.Drag.ReadValue<Vector2>());


        //          }
        //          else
        //          {


        //              TapRightEvent?.Invoke(null, EventArgs.Empty);

        //              //Tap();
        //              Debug.Log("RIght Tap");

        //          }


        //      };
        //inputAsset.Player.OneButtonMultiTap.performed +=
        //    ctx =>
        //    {
        //        //Debug.Log("MultiTap");


        //    };
        //FINGER DRAG
        //chache the started pos (for comparing later)
        //on performed check the cur pos with start pos
        //(if moved outside of threshold) then call drag shoot event
        //

   //     inputAsset.Player.TwoDrag.started +=
   //        ctx =>
   //        {

   //            Debug.Log("TwoStarted");



   //        };
   //     inputAsset.Player.TwoDrag.performed +=
   //        ctx =>
   //        {

   //            Debug.Log("TwoDragging");



   //        };
   //     inputAsset.Player.TwoDrag.canceled +=
   //ctx =>
   //{

   //    Debug.Log("TwoDraggingFinished");



   //};
        ////////////////////////////////////////////////////DRAGUPDATE////////////////////////////////////////////////
        //drag mouse
        inputAsset.Player.DragLeft.started +=
            ctx =>
            {
                
                LeftStartTime = Time.time;
                   
                DragLeftStartScreenPos = ctx.ReadValue<Vector2>();
                Debug.Log("Start");
                 LeftDragEvent?.Invoke(false);


            };

      
        //drag being performed
        inputAsset.Player.DragLeft.performed +=
            ctx =>
            {
                //Debug.Log("Drag" + (Camera.main.ScreenToWorldPoint(DragLeftStartScreenPos) - Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>())).magnitude);


                // Debug.Log("Dragging");
                //DragLeftStartScreenPos = ctx.ReadValue<Vector2>();

                //IF DRAG IS ABOVE X AMOUNT 
               

                    LeftDragVectorEvent?.Invoke(Camera.main.ScreenToWorldPoint(DragLeftStartScreenPos) - Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>()));
                    Debug.Log("Drag");

                

            };

        inputAsset.Player.DragLeft.canceled +=
            ctx =>
            {
                
                //if below drag threshold 
                //THIS IS A SAFE HOLD SO QUICK DRAG IS NOT COUNTED AS A TAP
                if ((Camera.main.ScreenToWorldPoint(DragLeftStartScreenPos) - Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>())).magnitude < minDragAmount)
                {

                    //how long since held down? is it a tap
                    if ((Time.time - LeftStartTime) <= TapTime)
                    {
                        Debug.Log((Time.time - LeftStartTime) + " : tap");
                        TapLeftEvent?.Invoke(null, EventArgs.Empty);
                    }
                   
                        //LeftDragEvent.Invoke(Camera.main.ScreenToWorldPoint(DragLeftStartScreenPos) - Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>()));   
                }
                
                
                    Debug.Log("Drag End");
                    LeftDragEvent?.Invoke(false);
                    LeftStartTime = 0;
                    DragLeftStartScreenPos = Vector2.zero;

             

            };




        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        inputAsset.Player.DragRight.started +=
           ctx =>
           {

               RightStartTime = Time.time;

               DragRightStartScreenPos = ctx.ReadValue<Vector2>();
               Debug.Log("Start");
               RightDragEvent?.Invoke(false);


           };


        //drag being performed
        inputAsset.Player.DragRight.performed +=
            ctx =>
            {
                //Debug.Log("Drag" + (Camera.main.ScreenToWorldPoint(DragLeftStartScreenPos) - Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>())).magnitude);


                // Debug.Log("Dragging");
                //DragLeftStartScreenPos = ctx.ReadValue<Vector2>();

                //IF DRAG IS ABOVE X AMOUNT 


                RightDragVectorEvent?.Invoke(Camera.main.ScreenToWorldPoint(DragRightStartScreenPos) - Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>()));
                Debug.Log("Drag");



            };

        inputAsset.Player.DragRight.canceled +=
            ctx =>
            {

                //if below drag threshold 
                //THIS IS A SAFE HOLD SO QUICK DRAG IS NOT COUNTED AS A TAP
                if ((Camera.main.ScreenToWorldPoint(DragRightStartScreenPos) - Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>())).magnitude < minDragAmount)
                {

                    //how long since held down? is it a tap
                    if ((Time.time - RightStartTime) <= TapTime)
                    {
                        Debug.Log((Time.time - RightStartTime) + " : tap");
                        TapRightEvent?.Invoke(null, EventArgs.Empty);
                    }

                    //LeftDragEvent.Invoke(Camera.main.ScreenToWorldPoint(DragLeftStartScreenPos) - Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>()));   
                }


                Debug.Log("Drag End");
                RightDragEvent?.Invoke(false);
                RightStartTime = 0;
                DragRightStartScreenPos = Vector2.zero;



            };

    }



    private void MultiTapActivated()
    {
        //Debug.Log("MultiTap");
    }

    private void Tap()
    {


    }

    private void SlowTapRelease()
    {
        //Debug.Log("SlowTapRelease");

    }

    private void SlowTapStarted()
    {
        //Debug.Log("SlowTapStarted");

    }

    public void OnDisable()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public bool IsTouchRight(Vector2 ScreenPos)
    {

        if (ScreenPos.x < (screenWidth / 2))
        {
            return true;

            //The User has touched on the left side of the screen
        }
        else
        {
            return false;
            //The user hase touched the right side of the screen 
        }

    }


    //    inputAsset.Player.Drag.started +=
    //            ctx =>
    //            {
    //                //chache the start pos

    //                //StartPos = ctx.ReadValue<Vector2>();
    //                //Debug.Log("DragStarted" + ctx.ReadValue<Vector2>() + "Magnitude" + ctx.control.EvaluateMagnitude());
    //                //ctx.control.EvaluateMagnitude())
    //                if (IsTouchRight(ctx.ReadValue<Vector2>()))
    //                {
    //                    DragRightStartScreenPos = ctx.ReadValue<Vector2>();
    //                }
    //                else

    //    DragLeftStartScreenPos = ctx.ReadValue<Vector2>();

    //            };

    ////drag being performed
    //inputAsset.Player.Drag.performed +=
    //    ctx =>
    //    {
    //        if (IsTouchRight(ctx.ReadValue<Vector2>()))
    //        {
    //                    //IF DRAG IS ABOVE X AMOUNT
    //                    if ((Camera.main.ScreenToWorldPoint(DragRightStartScreenPos) - Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>())).magnitude > minDragAmount)
    //            {



    //                        //Dragging Right
    //                        RightDragVectorEvent?.Invoke(Camera.main.ScreenToWorldPoint(DragRightStartScreenPos) - Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>()));
    //            }
    //            else
    //                        //IF DRAG IS ABOVE X AMOUNT
    //                        //Dragging Left
    //                        LeftDragVectorEvent?.Invoke(Camera.main.ScreenToWorldPoint(DragLeftStartScreenPos) - Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>()));

    //        }
    //                //Debug.Log((Camera.main.ScreenToWorldPoint(DragRightStartScreenPos) - Camera.main.ScreenToWorldPoint(inputAsset.Player.Drag.ReadValue<Vector2>())).magnitude); Debug.Log((Camera.main.ScreenToWorldPoint(DragRightStartScreenPos) - Camera.main.ScreenToWorldPoint(inputAsset.Player.Drag.ReadValue<Vector2>())).magnitude);
    //                //activate boost if not already active
    //                //SlowTapRelease();

    //                //Debug.Log("DragStarted" + ctx.ReadValue<Vector2>() + "Magnitude" + ctx.control.EvaluateMagnitude());
    //                //DragLeftScreenPosEvent()


    //                //Debug.Log("DragStarted" + ctx.ReadValue<Vector2>() + "Magnitude" + ctx.control.EvaluateMagnitude());
    //                //ctx.control.EvaluateMagnitude())


    //            };




    //    inputAsset.Player.RightClick.started +=
    //       ctx =>
    //       {


    //           if (ctx.interaction is SlowTapInteraction)
    //           {
    //                //TRIGGER SLOW TAP IF DRAG MAG Below ThreshHold
    //                if ((Camera.main.ScreenToWorldPoint(DragRightStartScreenPos) - Camera.main.ScreenToWorldPoint(inputAsset.Player.Drag.ReadValue<Vector2>())).magnitude<minDragAmount)
    //               {

    //                   slowTap = true;
    //                   SlowTapRightEvent?.Invoke(true);
    //    Debug.Log("slow Right tapStart");

    //               }
    //               else
    //{
    //    RightDragEvent?.Invoke(true);

    //    Debug.Log("Drag right Event Start");
    //    //Drag
    //    //show Charging boost and should tracks charge ampunt
    //    //SlowTapStarted();
    //}
    //            }
    //       };
    ////performed full charge (!have a canceled one to deal )
    //inputAsset.Player.RightClick.performed +=
    //      ctx =>
    //      {
    //                  // get side 
    //                  //check if other side is down (Two finger tap)

    //                  if (ctx.interaction is SlowTapInteraction)
    //          {
    //              if (slowTap == true)
    //              {
    //                  Debug.Log("Slow Tap right finished");
    //                  SlowTapRightEvent?.Invoke(false);
    //                  slowTap = false;

    //              }
    //              else
    //              {
    //                  Debug.Log("drag right finished");
    //                  RightDragEvent?.Invoke(false);

    //              }

    //                      //Debug.Log("sLowTap" + inputAsset.Player.Drag.ReadValue<Vector2>());

    //                      //activate boost if not already active
    //                      //SlowTapRelease();
    //                  }
    //          else
    //          {

    //                      //DragLeftStartScreenPos.
    //                      //inputAsset.Player.Drag.ReadValue<Vector2>();
    //                      TapRightEvent?.Invoke(null, EventArgs.Empty);

    //                      //Tap();
    //                      Debug.Log("RIght Tap");

    //          }


    //      };

}
