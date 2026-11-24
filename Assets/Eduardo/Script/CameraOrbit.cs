using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;
    public float distance = 6f;
    public Vector3 lookAtOffSet = new Vector3(0f, 0.5f, 0f);
    public float mouseSensitivity = 2f;
    public float minPitch = -20f;
    public float maxPitch = 70f;
    public LayerMask cameraCollisionMask = ~0;

    private float yaw;
    private float pitch = 20f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yaw = transform.eulerAngles.y;

        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            target = player.transform;
        }
    }

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Vector3 focus = target.position + lookAtOffSet;
        Vector3 dir = Quaternion.Euler(pitch, yaw, 0f) * Vector3.back;

        float dist = distance;
        
        if(Physics.SphereCast(focus, 0.2f, dir, out RaycastHit hit, distance, cameraCollisionMask, QueryTriggerInteraction.Ignore) && !hit.transform != target)
        {
            dist = hit.distance;
        }

        transform.position = focus + dir * dist;
        transform.LookAt(focus);
    }
}
