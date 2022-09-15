using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Walker : MonoBehaviour
{
    [SerializeField] private Transform planetCenter;
    [SerializeField] private Animator animator;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float groundCheckRadius;
    //[SerializeField]
    //private float slopeCheckDistance;

    [SerializeField]
    private Transform groundCheck;
    //[SerializeField]
    //private LayerMask whatIsGround;

    private float xInput;

    private int facingDirection = 1;

    //private Vector2 planetUpNormal;


    private Rigidbody2D rb;
    private CapsuleCollider2D cc;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckInput();
        animator.SetFloat("speed", Mathf.Abs(xInput));
    }

    private void FixedUpdate()
    {
        RotateUpright();
        ApplyMovement();
        ApplyGravity();
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (xInput == 1 && facingDirection == -1)
        {
            Flip();
        }
        else if (xInput == -1 && facingDirection == 1)
        {
            Flip();
        }
    }

    void RotateUpright()
    {
        //planetUpNormal = (Vector2)(planetCenter.position - transform.position).normalized;
        Vector2 distVec = (Vector2)planetCenter.position - (Vector2)transform.position;
        float angle = Mathf.Atan2(distVec.y, distVec.x) * Mathf.Rad2Deg;
        Quaternion flipQ = facingDirection == -1 ? Quaternion.AngleAxis(180, Vector3.up) : Quaternion.identity;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward) * flipQ;
    }

    private void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    void ApplyMovement()
    {
        Vector2 moveDir = (Vector2)transform.right;
        Vector2 moveVec = moveDir * xInput * movementSpeed * Time.fixedDeltaTime;
        rb.AddForce(moveVec);
    }

    void ApplyGravity()
    {
        Vector2 attractDir = (Vector2)planetCenter.position - rb.position;
        Vector2 attractVec = attractDir.normalized * Physics2D.gravity.sqrMagnitude * 100f * Time.fixedDeltaTime;
        rb.AddForce(attractVec);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
