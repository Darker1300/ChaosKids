using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AnimationLibrary
{
public class ToOrbitTest : MonoBehaviour
{
        OrbitRouteCalculator routeCalculator;
        public SimpleOrbit orbitLerp;
        public SimpleOrbit orbitExit;
      // public Transform planet;
        //public Transform ShootFromPos;
        OrbitProjectile projectile;
        public bool StartOrbit;
        public bool inOrbit = false;
        public float speed;
        public float Dtime = 0;





        // Start is called before the first frame update
        void Start()
    {
            projectile = GetComponent<OrbitProjectile>();
    }
      
        IEnumerator Orbit()
        {


            float Dtime = 0.0f;
            while (Dtime < 0.8f)
            {
                Dtime +=  (Time.deltaTime) * speed;
                LerpOrbit(Dtime);
                Debug.Log("Dtime" + Dtime);
                //yield return new WaitForSeconds(0.1f);
                yield return null;
            }
            float bulletOrbitTime = Random.Range(8, 25);
            Dtime = 0;
            inOrbit = true;
            while (Dtime < bulletOrbitTime)
            {
                Dtime += (Time.deltaTime) * speed;
                projectile.RotateAroundPoint();
               
                yield return null;
               
            }
            Dtime = 0f;
            //set the start value
            //CHANGE THIS
            orbitExit.orbitDatas.StartVector = transform.localPosition;

            
            Vector3 orbit = transform.forward * 40;
            // Rotates the orbit vector by degrees around the Y-Axis
            orbit = Quaternion.Euler(0, -orbitLerp.orbitDatas.EndVector.x, 0) * orbit;
            orbitExit.orbitDatas.EndVector = orbit.normalized * 20;
            orbitExit.StartFinished(true);
            while (Dtime < 0.5f)
            {
                Dtime += (Time.deltaTime) * speed;
                LerpOrbit(Dtime);
                Debug.Log("ToGround");
                yield return null;

            }
            yield return new WaitForSeconds(5);

            transform.localPosition = new Vector3(0,0,0);

        }


        // Update is called once per frame
        void Update()
    {
            //if (StartOrbit)
            //{
            //LerpOrbitConfigure(true);
            //    StartOrbit = false;
            //}

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
            ConfigureDirection(left);
            //quest start acalculates
            orbitLerp.StartFinished(StartStop);

            StartCoroutine(Orbit());
        }
        public void ConfigureDirection(bool left)
        {
            if (left)
            { 
            projectile.speed = 25;
            orbitLerp.orbitDatas.EndVector.x = -20f;
            } else
            {
                projectile.speed =-25;
                orbitLerp.orbitDatas.EndVector.x = 20f;

            }



        }
}
}
