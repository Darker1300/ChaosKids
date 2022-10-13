using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using UnityEngine.Events;

public class DiscSizeLerp : MonoBehaviour
{
    public Disc m_Disc = null;
    public float m_NewDiskRadius = 0.0f;
    public float m_LerpDuration = 0.0f;
    
    [SerializeField] public UnityEvent OnFinishLerp;

    public float tValue = 0.0f;
    public bool lerping = false;
    public float currentRadius;
  
    private void Start()
    {
        currentRadius = m_Disc.Radius;
    }

    private void Update()
    {


        if (lerping)
        {
            if (tValue < m_LerpDuration)
            {
                m_Disc.Radius = Mathf.Lerp(currentRadius, m_NewDiskRadius, tValue / m_LerpDuration);
                tValue += Time.deltaTime;           
            }
            else
            {
                m_Disc.Radius = m_NewDiskRadius;
                lerping = false;
                OnFinishLerp?.Invoke();
            }     
        }
    }

    public void LerpToSize(float newSize)
    {
       
        currentRadius = m_Disc.Radius;
        m_NewDiskRadius = newSize;
        lerping = true;
    }
}
