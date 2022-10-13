using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shapes;

public class SlingItem : MonoBehaviour
{
    public Color hoverColor;
    public Color baseColor;
    //List to update background 
    private Disc backgroundImage;
    public Image ItemImage;
    public GameObject ItemObject;

    // Start is called before the first frame update
    void Start()
    {
        backgroundImage = GetComponent<Disc>();
        backgroundImage.Color = baseColor;
        //ItemImage.enabled = true;
        //Deselect();
    }
    private void OnEnable()
    {
        ItemImage.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Select()
    {
        backgroundImage.Color = hoverColor;
        ItemImage.enabled = true;
    }

    public void Deselect()
    {
        backgroundImage.Color = baseColor;
        ItemImage.enabled = false;
    }
    public void ActivateActionItem()
    {
        //ItemObject.SetActive(true);
    }
}
