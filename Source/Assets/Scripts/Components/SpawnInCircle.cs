using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInCircle : MonoBehaviour
{
    public bool spawnObjects;
    public GameObject SpawnInCirclePrefab;
    public List<GameObject> ObjSpawnInCircles;
    public int numberToSpawn;
    public float radius;
    public float Offset;
    public bool HasJoint;
    public Rigidbody2D rb;
    public bool randomAmount;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnObjects)
        {
            
            SpawnAroundCircle();
            spawnObjects = false;
        }
    }

    public void SpawnAroundCircle()
    {
        radius = GetComponent<Shapes.Disc>().Radius;
        numberToSpawn = (!randomAmount) ? numberToSpawn  : Random.Range(2, 8);
       
        radius += Offset;
        for (int i = 0; i < numberToSpawn; i++)
        {
            float theta = i * 2 * Mathf.PI / numberToSpawn;
            float x = Mathf.Sin(theta) * radius;
            float y = Mathf.Cos(theta) * radius;
            Vector2 newPos = new Vector3(x, y, 0);
            GameObject spawnedObj = Instantiate(SpawnInCirclePrefab,Vector3.zero, transform.rotation);
           
            //spawnedObj.transform.parent = transform;

            spawnedObj.transform.position =transform.position +  new Vector3(x, y, 0);
            spawnedObj.transform.up = new Vector3(x, y, 0);
            //spawnedObj.GetComponent<DiscSizBounce>().lerping = true;
            if (spawnedObj.GetComponent<DistanceJoint2D>() != null)
            {
                spawnedObj.GetComponent<DistanceJoint2D>().connectedBody = rb;
                spawnedObj.GetComponent<DistanceJoint2D>().distance = 30;
                
                


            }
                //spawnedObj.GetComponent<DistanceJoint2D>().attachedRigidbody.Equals(GetComponent<Rigidbody2D>());

                    ObjSpawnInCircles.Add(spawnedObj);
        }



    }
    
   
}
