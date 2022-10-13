using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AngleActionTypeSelector : MonoBehaviour
{
        
    public UnityEvent<bool,bool> DirectionActivateItem;
    public Vector2 normalisedMousePosition;
    public float currentAngle;
    public int selection;
    public int previousSelection;
    Vector2 dragCurrent;
    //public SlingMain slingMain;
    public DragConverter dragConverter= new DragConverter();
    public GameObject[] SlingActionHolder;


    private SlingItemSelector MenuActionSc;
    private SlingItemSelector previousMenuActionSc;
    [SerializeField]
    private int CircleDivisions;
    //[SerializeField]
    private float sectionAngleValue;

    [SerializeField]
    private float UiRotationOffset = 0;
    [SerializeField]
    private float minDragAmount;
    private bool startSelected;
    public ProjectileLoaderInterface projectileLoader;
    private void OnEnable()
    {
        //previousSelection = 1;
        InputManager.RightDragVectorEvent += SetActionTypeSelection;
    }
    private void OnDisable()
    {
        ActivateActionItem();
        //previousSelection = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        //slingMain = GetComponent<SlingMain>();
        sectionAngleValue = 360 / CircleDivisions;
        UiRotationOffset = GetComponent<RectTransform>().eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        //if (slingMain.LeftMouseDown)
        //SetActionTypeSelection();
        
    }

    public void SetActionTypeSelection(Vector2 drag)
    {
        dragCurrent = drag;
        //or make it an event
        if ( dragCurrent.magnitude > minDragAmount)
        {
            Debug.DrawLine(transform.position, -dragCurrent);
            normalisedMousePosition = -dragCurrent;
            currentAngle = Mathf.Atan2(normalisedMousePosition.y, normalisedMousePosition.x) * Mathf.Rad2Deg;
            currentAngle = (((currentAngle + 360) + UiRotationOffset) % 360) - 1;
            // selection = currentAngle / (360 / 8); which is VV
            selection = (int)currentAngle / (int)sectionAngleValue;

            // 
            if (selection != previousSelection || startSelected == false)
            {
                startSelected = true;
                previousMenuActionSc = SlingActionHolder[previousSelection].GetComponent<SlingItemSelector>();
                previousMenuActionSc.Deselect();

                //previousMenuActionSc.SlingItems[previousMenuActionSc.selection].GetComponent<SlingItem>().Deselect();
                previousSelection = selection;

                MenuActionSc = SlingActionHolder[selection].GetComponent<SlingItemSelector>();

            }
            if (MenuActionSc != null)
            {
                //the item in the section
                MenuActionSc.SetItemSelection(drag.magnitude);
            }
            //Debug.Log(currentAngle);   
            //else MenuActionSc.Deselect();
        }
        else if (MenuActionSc != null)
        {
            MenuActionSc.Deselect();
            MenuActionSc = null;
            startSelected = false;
        } 

    }
    public void ActivateActionItem()
    {
        switch (selection)
        {
            case 0:
                projectileLoader.ConfigureDirection(true, true);
                break;
            case 1:

                break;
            case 2:
                projectileLoader.ConfigureDirection(true, false);
                break;
            case 3:

                break;
        }

    }
    
    /// 
    /// set a drag limit , devide that limit into sections depending the number of different sections available
    /// sub actions need to be a list which will be updated depending on available sub actions
    /// ui will displayed in the center 
    /// 
    /// 
    /// 
    /// 
    // Start is called before the first frame update

}
