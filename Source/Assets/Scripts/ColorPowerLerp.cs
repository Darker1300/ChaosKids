using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPowerLerp : MonoBehaviour
{
    public ParticleSystem particleDash;
    
    LineRenderer ln;
    public LineRenderer tailLineRenderer;
    [SerializeField] [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color[] myColors;
    int colorIndex = 0;
    float t = 1f;
    int ColorLength;

    // Start is called before the first frame update
    void Start()
    {
        ln = GetComponent<LineRenderer>();
        ln.material.color = myColors[0];

        ColorLength = myColors.Length;

    }

    // Update is called once per frame
    void Update()
    {
        if (colorIndex >= 0)
        {


            //Debug.Log("t= " + t);
            //Lerp up to colour
            //lerp down to white
            ln.material.color = Color.Lerp(ln.material.color, myColors[0], lerpTime * Time.deltaTime);
            t = Mathf.Lerp(t, 0f, lerpTime * Time.deltaTime);
            particleDash.GetComponent<ParticleSystemRenderer>().material.color = ln.material.color;
            //this checks 
            //tailLineRenderer.endColor = ln.material.color;
            if (t < .2f)
            {

                t = 1;



                colorIndex = (colorIndex > 0) ? colorIndex -= 1 : 0;
            }
        } else ln.material.color = myColors[0];
    }

    public void updateDashColors(int dashTier)
    {
        ln.material.color = myColors[dashTier + 1];
        colorIndex = dashTier;
    }
 //if (colorIndex > 0)
 //       {


 //           Debug.Log("t= " + t);
 //           //Lerp up to colour
 //           //lerp down to white
 //           ln.material.color = Color.Lerp(ln.material.color, myColors[colorIndex], lerpTime* Time.deltaTime);
 //           t = Mathf.Lerp(t, 0f, lerpTime* Time.deltaTime);
 //   particleDash.GetComponent<ParticleSystemRenderer>().material.color = ln.material.color;
 //           //this checks 
 //           if (t< .2f)
 //           {

 //               t = 1;



 //               colorIndex = (colorIndex > 0) ? colorIndex -= 1 : 0;
 //           }
 //       } else ln.material.color = myColors[0];
}
