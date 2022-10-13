using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    public GameObject planet;
    public bool applyGravity;
    public Vector2 planetGravity;
    Rigidbody2D rb;

    public float gravityForce;
    public float gravityDistance;
    float lookAngle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (applyGravity)
        {
            float dist = Vector3.Distance(gameObject.transform.position, planet.transform.position);
            Vector3 v = planet.transform.position - transform.position;
            planetGravity = v.normalized * (1.0f - dist / gravityDistance) * gravityForce;
            rb.AddForce(planetGravity);
            lookAngle = 90 + Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);
        }

    }
}
