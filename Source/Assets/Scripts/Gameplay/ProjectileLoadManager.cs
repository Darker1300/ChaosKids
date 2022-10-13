using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLoadManager : MonoBehaviour
{
    public ObjectPooler objPooler;
    public List <ObjectPooler> projParticlePooler;

    public Vector2 spawnPoint;
    public Transform planet;
    public Vector2 TempDrag;
    
   // PrecissionStrike precStrike;
    //call Spawn object

    // Start is called before the first frame update
    void Start()
    {
        InputManager.LeftDragVectorEvent += Test2;
        InputManager.LeftDragEvent += Testrelease;
        objPooler.CreatePool(20);
        projParticlePooler[0].CreatePool(20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //////////////////////////////////////////////Testing///////////////////////////////////////////////////////////
    public void Testrelease(bool state)
    {
        if (!state)
        {
            Spawn(TempDrag);
        }
        


    }
    public void Test2(Vector2 drag)
    {
        if (drag != Vector2.zero)
        {

        }
        TempDrag = drag;
        Debug.DrawLine(transform.position, TempDrag);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //configure orbit info
    public void Spawn(Vector2 dragDirection)
    {
       GameObject proj = objPooler.SpawnFromPool(spawnPoint,planet,false);
        proj.GetComponent<PrecissionStrike>().Strike(dragDirection);

    }


    public void HasLanded(GameObject proj, int particleIndexer,Vector3 hitDirectionPos )
    {
        //proj.GetComponent<PrecissionStrike>().Strike(dragDirection);
        var projt = projParticlePooler[particleIndexer].SpawnFromPool(planet.TransformPoint( hitDirectionPos),planet,true);
        projt.transform.up = hitDirectionPos.normalized;
        objPooler.ReturnToPool(proj);
        //GameObject proj = objPooler.SpawnFromPool(spawnPoint, planet, false);
        //projt.transform.localScale = new Vector3(1, 1, 1);
        //proj.transform.position = transform.position;
    }
}
