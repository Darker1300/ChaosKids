using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(GravityPlanetApplier))]
public class AddSidewardsForce : MonoBehaviour
{

    Rigidbody2D rb;
    private GravityPlanetApplier applier;
    // Start is called before the first frame update
    void Start()
    {
        applier = GetComponent<GravityPlanetApplier>();
        applier.OnPlanetInfluence += applySidewaysForce;
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void applySidewaysForce(Vector2 planetDirection)
    {
        //Vector2 mDir = (Vector2)transform.up * 100f;
        Vector2 mDir = new Vector2();

        float dotUp = -Vector2.Dot(rb.velocity, (Vector2)(transform.up));
        //Debug.Log(dotUp);
        //check 
        if (Vector2.Dot(rb.velocity, transform.right) <= 0)
        {
            mDir += -Vector2.right * dotUp;

        }
        else mDir += Vector2.right * dotUp;
        //intialOrbitEnter = false;
        rb.velocity += mDir *2 * Time.deltaTime;
    }
}
