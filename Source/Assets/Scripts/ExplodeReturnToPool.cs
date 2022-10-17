using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeReturnToPool : MonoBehaviour
{
    public ProjectileLoadManager projLoader;
    public int particleTypeIndex;
    private Transform StartTrans;
    private void OnEnable()
    {
        StartTrans = transform;
        StopAllCoroutines();
        StartCoroutine(timer());
    }

    

        private void OnDisable()
    {

        StopAllCoroutines();
        //transform.position = StartTrans.position;
        //transform.rotation = StartTrans.rotation;
    }
    // Start is called before the first frame update
    void Awake()
    {
        projLoader = FindObjectOfType<ProjectileLoadManager>();
    }
    IEnumerator timer()
    {
        float Dtime = 0.0f;
        while (Dtime < 1.8f)
        {

            
            //yield return new WaitForSeconds(0.1f);
            yield return null;
        }
        projLoader.projParticlePooler[particleTypeIndex].ReturnToPool(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }

}