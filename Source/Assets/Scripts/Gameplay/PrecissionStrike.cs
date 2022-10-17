using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimationLibrary;

public class PrecissionStrike : MonoBehaviour
{

    public OrbitRouteCalculator routeCalculator;
    public RaycastCheck rayCheck;
    public SimpleOrbit orbitLerp;
    public SimpleOrbit orbitExit;
    //public Transform planet;
    //public Transform ShootFromPos;
   public PrecissionStrike projectile;
    public bool StartOrbit;
    public bool inOrbit = false;
    public float speed;
    public float Dtime = 0;
    public float IntoOrbitTime;
    public float actualOrbitTime;
    public SlingMain slingMain;
    public bool takeShortestPath;
    public ProjectileLoadManager projLoader;

    // Start is called before the first frame update
    void Awake()
    {
        slingMain = FindObjectOfType<SlingMain>();
        routeCalculator = FindObjectOfType<OrbitRouteCalculator>();
        projectile = GetComponent<PrecissionStrike>();
        rayCheck = GetComponent<RaycastCheck>();
        projLoader = FindObjectOfType<ProjectileLoadManager>();

        //InputManager.OnMouseLeftDownRelease += Strike;
    }
    private void OnEnable()
    {
        orbitLerp.StartFinished(true);
    }
    private void OnDisable()
    {
        inOrbit = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Strike(Vector2 Direction)
    {
        routeCalculator.CalculateOrbit(new Vector3(0,1,0), new Vector3(Direction.x,Direction.y,0), ref orbitLerp.orbitDatas,ref orbitExit.orbitDatas,ref actualOrbitTime,ref projectile);
        
        LerpOrbitConfigure(true, true);

    }
    IEnumerator Orbit()
    {
        float Dtime = 0.0f;
        while (Dtime < 0.8f)
        {

            Dtime += (Time.deltaTime) * speed;
            LerpOrbit(Dtime);
            Debug.Log("Dtime" + Dtime);
            //yield return new WaitForSeconds(0.1f);
            yield return null;
        }
        //float bulletOrbitTime = Random.Range(8, 25);
        Dtime = 0;
        inOrbit = true;
        while (Dtime < actualOrbitTime)
        {
            Dtime += (Time.deltaTime);
            projectile.GetComponent<OrbitProjectile>().RotateAroundPoint();

            yield return null;

        }
        Dtime = 0f;
        //set the start value
        //CHANGE THIS
        //orbitExit.orbitDatas.StartVector = transform.localPosition;
        

        //Vector3 orbit = transform.forward * 40;
        // Rotates the orbit vector by degrees around the Y-Axis
        //orbit = Quaternion.Euler(0, -orbitLerp.orbitDatas.EndVector.x, 0) * orbit;
        //orbitExit.orbitDatas.EndVector = orbit.normalized * 20;
        orbitExit.StartFinished(true);
        while (Dtime < 1.0f)
        {
            Dtime += (Time.deltaTime);
            LerpOrbit(Dtime);
            Debug.Log("ToGround");
            yield return null;

        }
        ReturnToPool();
        yield return new WaitForSeconds(5);
        //transform.localPosition = new Vector3(0, 0, 0);

    }

    public void LerpOrbit(float LERP)
    {
        if (!inOrbit)
        {
            orbitLerp.LerpOrbit(LERP);
            transform.localPosition = orbitLerp.GetPosition();
        }
        else if (inOrbit)
        {
            orbitExit.LerpOrbit(LERP);
            transform.localPosition = orbitExit.GetPosition();
        }
    }
   
    public void LerpOrbitConfigure(bool StartStop, bool left)
    {
        //routeCalculator.CalculateOrbit()
        //ConfigureDirection(left);
        //quest start acalculates
        orbitLerp.StartFinished(StartStop);

        StartCoroutine(Orbit());
    }
    public void ReturnToPool()
    {

        projLoader.HasLanded(this.gameObject,GetComponent<ExplodeReturnToPool>().particleTypeIndex, orbitExit.orbitDatas.EndVector);
        
    }
   
    public void Explosion()
    {


    }
}
