using UnityEngine;

public class Walker : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Transform planetCenter;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float speed;
    [SerializeField] private float slopeRayLength = 3f;

    [Header("Debug")]
    [SerializeField] private float xInput;

    [SerializeField] private Vector2 capsuleColliderSize;
    [SerializeField] private Vector2 planetUpNormal;
    [SerializeField] private Vector2 groundNormal;
    [SerializeField] private Vector2 groundNormalPerp;
    [SerializeField] private Vector2 newVelocity;
    [SerializeField] private Vector2 newForce;
    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] private CapsuleCollider2D capsule2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        capsule2D = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        GatherInput();
    }

    private void FixedUpdate()
    {
        // Planet Normal
        planetUpNormal = (Vector2)(transform.position - planetCenter.position).normalized;

        Vector2 capsuleBasePos = (Vector2) transform.position;
        RaycastHit2D hitDown = Physics2D.Raycast(capsuleBasePos, -planetUpNormal, slopeRayLength, groundLayer);
        if (hitDown)
        {
            groundNormal = hitDown.normal;
            groundNormalPerp = Vector2.Perpendicular(hitDown.normal).normalized;

            Debug.DrawRay(hitDown.point, groundNormalPerp, Color.blue);
            Debug.DrawRay(hitDown.point, hitDown.normal, Color.green);
        }
        else
        {
            groundNormal = (Vector2)transform.up;
            groundNormalPerp = (Vector2)transform.right;
        }

    }

    private void OnDrawGizmosSelected()
    {

    }


    private void GatherInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
    }

}
