using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path2DWalker : MonoBehaviour
{
    [Header("References")]
    public NavMeshHelper planetHelper = null;
    public Animator animator = null;
    public SpriteRenderer spriteRenderer = null;

    [Header("Config")]
    public Transform targetTransform = null;
    public float speed = 5;
    public bool flipX = false;

    public float maxVelocity = 3.5f;
    public float maxAcceleration = 10f;

    [Header("Debug")]
    public float velocity = 0f;

    public bool facingRight = true;
    public float currentDistance;
    public float targetDistance;
    public Path2D planetPath = null;


    void Start()
    {
        planetHelper ??= GameObject.FindObjectOfType<NavMeshHelper>();
        planetPath ??= planetHelper?.planetPath;
        animator ??= GetComponent<Animator>();
        spriteRenderer ??= GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (!targetTransform) return;

        currentDistance = planetPath.GetClosestDistanceAlongPath(transform.position);
        targetDistance = planetPath.GetClosestDistanceAlongPath(targetTransform.position);

        float delta = DeltaAngle(currentDistance, targetDistance, planetPath.length);

        float newDistance =
            Mathf.MoveTowards(currentDistance, currentDistance + delta,
                                                  speed * Time.deltaTime);

        transform.position = planetPath.GetPointAtDistance(newDistance);

        var planetPos = planetHelper.planetCenter.position;
        var lookDir = (transform.position - planetPos).normalized;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDir);

        if (!animator || !spriteRenderer) return;

        animator.SetFloat("speed", Mathf.Clamp01(Mathf.Abs(delta)));

        if (delta < -0.01f) facingRight = flipX ? false : true;
        else if (delta > 0.01f) facingRight = flipX ? true : false;

        spriteRenderer.flipX = !facingRight;
    }

    // Calculates the shortest difference between two given angles in a repeating range.
    public static float DeltaAngle(float current, float target, float maxAngle = 360f)
    {
        float delta = Mathf.Repeat((target - current), maxAngle);
        if (delta > maxAngle / 2f)
            delta -= maxAngle;
        return delta;
    }


    #region Steering

    ///// <summary>
    ///// Updates the velocity of the current game object by the given linear
    ///// acceleration
    ///// </summary>
    //public void Steer(Vector2 linearAcceleration)
    //{
    //    velocity += linearAcceleration * Time.deltaTime;

    //    if (velocity.magnitude > maxVelocity)
    //    {
    //        velocity = velocity.normalized * maxVelocity;
    //    }
    //}

    ///// <summary>
    ///// A seek steering behavior. Will return the steering for the current game object to seek a given position
    ///// </summary>
    //public float Seek(float targetDistance, float maxSeekAccel)
    //{
    //    /* Get the direction */
    //    float acceleration = targetDistance - currentDistance;

    //    acceleration = Mathf.Sign(acceleration);

    //    /* Accelerate to the target */
    //    acceleration *= maxSeekAccel;

    //    return acceleration;
    //}

    //public Vector2 Seek(Vector2 targetPosition)
    //{
    //    return Seek(targetPosition, maxAcceleration);
    //}

    //public float GetCohesion(ICollection<Path2DWalker> targets)
    //{
    //    float centerDistance = 0f;
    //    int count = 0;

    //    /* Sums up everyone's position who is close enough and in front of the character */
    //    foreach (Path2DWalker r in targets)
    //    {
    //        if (facingRight ? r.currentDistance > currentDistance : r.currentDistance < currentDistance)
    //        {
    //            centerDistance += r.currentDistance;
    //            count++;
    //        }
    //    }

    //    if (count == 0)
    //    {
    //        return Vector3.zero;
    //    }
    //    else
    //    {
    //        centerOfMass = centerOfMass / count;

    //        return steeringBasics.Arrive(centerOfMass);
    //    }
    //}
    #endregion

}
