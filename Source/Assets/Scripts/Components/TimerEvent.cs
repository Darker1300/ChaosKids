using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TimerEvent : MonoBehaviour
{
   public UnityEvent TimeUpDoThis;
    
    public bool startTimer;
    public float Duration;
    public bool Loop;
    public bool startOnAwake;
    // Start is called before the first frame update
    void Start()
    {
        if (startOnAwake)
        {
            StartCoroutine(CallEventAftertimeUp());
        }
    }
    IEnumerator CallEventAftertimeUp()
    {
        yield return new WaitForSeconds(Duration);

        TimeUpDoThis.Invoke();
        if (Loop)
        {
            StartCoroutine(CallEventAftertimeUp());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimer()
    {
        StartCoroutine(CallEventAftertimeUp());
    
    }
}
