using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using UnityEngine.Events;

public class ThrowAwayColorLerp : MonoBehaviour
{
    public UnityEvent<float> Lerping;

    public UnityEvent<bool> OnStartBounce;
    [SerializeField]
    public ShapeRenderer shapeRenderer;
    [SerializeField]
    Color start;
    [SerializeField]
    Color end;
    
    [SerializeField]
    [Range(0f,1f)]
    public float TVal;
    public bool startit;
    public bool lerp;
    public bool increase;
    public float speed;
    public bool TestSize;
    public float StartSize;
    public float EndSize;
    public bool pingpong = true;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startIt();
        if (lerp)
        {
            //TVal = Mathf.Clamp(Mathf.PingPong(Time.time, 1), 0.1f, 1f);
            if (pingpong)
            {
                TVal = Mathf.PingPong(Time.time * speed, 1);
            } else 
            TVal =(Time.time * speed)% 1;
            if (TVal == 0.0f)
            {
                OnStartBounce?.Invoke(true);
            }
           
            Lerping?.Invoke(TestSize ? Mathf.Lerp(StartSize, EndSize, TVal) : TVal);

           // Lerping?.Invoke(TVal);
        }
       

      
        //shapeRenderer.Color = Color.Lerp(start, end, colorVal);
    }
    public void startIt()
    {
        if (startit)
        {
            lerp = true;
            startit = false;
            OnStartBounce?.Invoke(true);
        }
    }

}
