using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerBall;
    public Transform cameraTransform;
    public float moveForce = 10f;
    public float maxSpeed = 8f;
    public float mouseSensitivity = 2f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private float xRotation;
    private float yRotation;
    private bool isGrounded;

    void Start()
    {
        rb = playerBall.GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.angularDamping = 0.05f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Look();

        isGrounded = Physics.Raycast(transform.position, Vector3.down,GetComponent<SphereCollider>().radius + 0.1f);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void LateUpdate()
    {
        cameraTransform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        
        transform.position = playerBall.position;
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = (transform.right * x + transform.forward * z).normalized;
        rb.AddForce(inputDir * moveForce, ForceMode.Acceleration);

        // Limit horizontal maximum speed
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (flatVel.magnitude > maxSpeed)
        {
            Vector3 capped = flatVel.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(capped.x, rb.linearVelocity.y, capped.z);
        }
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
    }
}
