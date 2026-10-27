using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform ballMesh;
    public float ballRadius = 0.5f;
    public float walkSpeed = 4f;
    public float sprintSpeed = 7f;
    public float mouseSensitivity = 2f;
    public float jumpForce = 8f;
    public float gravity = -20f;

    private CharacterController controller;
    private float xRotation;
    private float verticalVelocity;
    private bool isGrounded;

    private Vector3 lastPosition;
    private Quaternion ballRotation;

    private Material currentSkybox;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        lastPosition = transform.position;
        ballRotation = ballMesh.rotation;
    }

    void Update()
    {
        Look();
        Move();
    }

    void LateUpdate()
    {
        RollBall();
    }

    void RollBall()
    {
        Vector3 velVector = transform.position - lastPosition;
        velVector.y = 0f;
        lastPosition = transform.position;

        if (velVector.sqrMagnitude > 0.000001f)
        {
            Vector3 axis = Vector3.Cross(Vector3.up, velVector.normalized);
            float angle = (velVector.magnitude / ballRadius) * Mathf.Rad2Deg;
            ballRotation = Quaternion.AngleAxis(angle, axis) * ballRotation;
        }

        ballMesh.rotation = ballRotation;
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void Move()
    {
        isGrounded = controller.isGrounded;

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        Vector3 move = (transform.right * x + transform.forward * z).normalized * speed;

        if (isGrounded && verticalVelocity < 0f)
            verticalVelocity = -2f;

        if (isGrounded && Input.GetButtonDown("Jump"))
            verticalVelocity = jumpForce;

        verticalVelocity += gravity * Time.deltaTime;
        move.y = verticalVelocity;

        controller.Move(move * Time.deltaTime);
    }
}
