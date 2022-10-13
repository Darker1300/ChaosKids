using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shapes;


public class SlingItemSelector : MonoBehaviour
{

    public GameObject[] SlingItems;

    public int actionType;
    private SlingItem MenuItemSc;
    private SlingItem previousMenuItemSc;
    public int selection;
    public int previousSelection;
    private float CMagnitude;
   
    //[SerializeField]
    //private float sectionAngleValue;
    [SerializeField]
    private float DragMaxValue;
    [SerializeField]
    private float sectionLengthValue;

    void Start()
    {
        ConfigureSections();
    }
    public void ConfigureSections()
    {
        sectionLengthValue = DragMaxValue / (SlingItems.Length ); 
    
    }
    // Update is called once per frame

    //private void OnDisable()
    //{
    //    MenuItemSc.ActivateActionItem();
    //    //previousSelection = 1;
    //}
    //public void SetItemSelection(float magnitude)
    //{
    //    //backgroundImage.Color = hoverColor;

    //}
    private void OnDisable()
    {
        if (SlingItems[selection] != null)
        {
            //ActivateItem.Invoke();
        }
    }
    public void Deselect()
    {

        SlingItems[selection].GetComponent<SlingItem>().Deselect();

        //previousSelection = 0;
        ////previousMenuItemSc.Deselect();
        ////selection = 0;
        // SlingItems[selection].GetComponent<SlingItem>().Deselect();
        //SlingItems[previousSelection].GetComponent<SlingItem>().Deselect();
        //selection = 0;
        //SlingItems[previousSelection].GetComponent<SlingItem>().Deselect();
        //SlingItems[previousSelection].GetComponent<SlingItem>().Deselect();
        //backgroundImage.Color = baseColor;
    }



    //public Vector2 normalisedMousePosition;
    //public float currentAngle;


    //SlingMain slingMain;
    //public GameObject[] SlingItems;
    public void Select()
    {
        SlingItems[selection].GetComponent<SlingItem>().Select();


    }




    //[SerializeField]
    //private float UiRotationOffset = 0;
    //[SerializeField]
    //private float minDragAmount;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    slingMain = GetComponent<SlingMain>();
    //    sectionAngleValue = 360 / CircleDivisions;
    //    UiRotationOffset = GetComponent<RectTransform>().eulerAngles.z;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    SetItemSelection();


    //}

    public void SetItemSelection(float magnitude)
    {
        //or make it an event
        if (magnitude < DragMaxValue)
        {

        
        CMagnitude = Mathf.Clamp(magnitude, 0, DragMaxValue);
        }
        else
        {
            CMagnitude = DragMaxValue;
        } 

        //it is doing this because it only checks once angle has changed when it should be constantly checking while in angle
        selection = (int)(CMagnitude / sectionLengthValue )-1;
        selection = Mathf.Clamp(selection, 0, SlingItems.Length - 1);
        Select();
        // 
        if (selection != previousSelection)
        {
            previousMenuItemSc = SlingItems[previousSelection].GetComponent<SlingItem>();
            previousMenuItemSc.Deselect();
            previousSelection = selection;

            MenuItemSc = SlingItems[selection].GetComponent<SlingItem>();
            MenuItemSc.Select();
        }
        Debug.Log("item " + selection);
        //Debug.Log("item "+magnitude);
    }
        
        //}

    }
