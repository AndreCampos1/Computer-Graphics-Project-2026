using UnityEngine;

public class Player3 : MonoBehaviour
{
    public Transform cameraTransform;

    private float radius = 0.5f;

    [Header("Movement")]
    public float moveForce = 25f;
    public float maxSpeed = 8f;
    public float sprintMaxSpeed = 12f;
    public float sprintForceMultiplier = 1.5f;
    [Range(0f, 1f)] public float airControl = 0.3f;

    [Header("Jump")]
    public float jumpSpeed = 6f;
    public float groundCheckDistance = 0.1f;
    public LayerMask groundMask = ~0;

    private Rigidbody rb;
    private Vector3 inputDir;
    private bool sprinting;
    private bool jumpQueued;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        SphereCollider sc = GetComponent<SphereCollider>();

        if (cameraTransform == null)
        {
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            cameraTransform = camera.transform;
        }
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0f;
        camRight.Normalize();

        inputDir = Vector3.ClampMagnitude(camForward * z + camRight * x, 1f);
        sprinting = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetButtonDown("Jump")) jumpQueued = true;
    }

    void FixedUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, radius + groundCheckDistance, groundMask, QueryTriggerInteraction.Ignore);

        float control = isGrounded ? 1f : airControl;
        float force = moveForce * (sprinting ? sprintForceMultiplier : 1f) * control;
        rb.AddForce(inputDir * force, ForceMode.Acceleration);

        float limit = sprinting ? sprintMaxSpeed : maxSpeed;
        Vector3 v = rb.linearVelocity;
        Vector3 flat = new Vector3(v.x, 0f, v.z);
        if(flat.magnitude > limit)
        {
            flat = flat.normalized * limit;
            rb.linearVelocity = new Vector3(flat.x, v.y, flat.z);
        }

        if(jumpQueued && isGrounded) rb.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);

        jumpQueued = false;
    }
}
