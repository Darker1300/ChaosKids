using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    Rigidbody2D rb;
    PlanetGravity planetGravity;
    public Vector2 SlingDirection;
    public bool Fired;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();


    }
    private void OnEnable()
    {

        //rb.velocity = Vector3.up * 80;
    }
    public void ApplyForce()
    {
        
            //rb.AddForce(-transform.up * 800);

    }

    // Update is called once per frame
    void Update()
    {
       rb.AddForce(-transform.up * 100f/Time.deltaTime ) ;
        //rb.AddForce(-transform.up * 80);
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && collision.gameObject != planetGravity.gameObject)
        {


            //planetGravity.planet = collision.gameObject;
            //planetGravity.applyGravity = true;
            //transform.rotation = rotation;
            //Quaternion.Slerp(  transform.rotation, rotation, 0.01f * Time.deltaTime);
            //transform.Rotate(rotation.eulerAngles);
            //transform.Rotate()= Quaternion.Euler(rotation.x) rotation;
            Quaternion _rotation = transform.rotation;
            rb.AddForce(collision.gameObject.GetComponent<GravitationalAtractor>().GetObjectToPlanet(transform.position, ref _rotation));
            
            transform.rotation = _rotation;

            //CurrentState = playerStates.DEFAULT;

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //intialOrbitEnter = true;


        if (collision.gameObject.layer == 6 && collision.gameObject != planetGravity.gameObject)
        {

            //if (Vector2.Dot(rb.velocity, transform.right) <= 0)
            //{
            //    moveDirection = -Vector2.right;

            //}
            //else moveDirection = Vector2.right;

            // Grounded = true;
            //planetGravity.planet = collision.gameObject;
            //planetGravity.applyGravity = true;
           // var a = Quaternion.Angle(transform.rotation, rotation2);
            //StartCoroutine(RotateOverTime(rotation1, rotation2, a / speed));
            //StartCoroutine( RotateOverTime(transform.rotation, rotation2));
            //Quaternion.Slerp(  transform.rotation, rotation, 0.01f * Time.deltaTime);
            //transform.Rotate(rotation.eulerAngles);
            //transform.Rotate()= Quaternion.Euler(rotation.x) rotation;

           

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            //Grounded = false;
            //Grounded = false;

        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Collided");
        if (collision.gameObject.layer == 6)
        {
            rb.isKinematic = false;
            //if (intialOrbitEnter == true)
            //{
            //    ////how verticle is its movement
            //    //float dotUp =  -Vector2.Dot(rb.velocity, (Vector2)(transform.up));
            //    ////check 
            //    //if (Vector2.Dot(rb.velocity, transform.right) <= 0)
            //    //{

            //    //    moveDirection =( -Vector2.right* dotUp) * slingAmount;

            //    //}
            //    //else moveDirection =( Vector2.right * dotUp) * slingAmount;
            //    intialOrbitEnter = false;
            //}



            //Grounded = false;

        }


    }
}
