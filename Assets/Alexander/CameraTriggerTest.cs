using UnityEngine;

public class CameraTriggerTest : MonoBehaviour
{

    [SerializeField] public GameObject camera;
    [SerializeField] float triggerHeight = 5f;
    [SerializeField] GameObject globalVolume;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (camera.transform.position.y < triggerHeight)
        {
            Debug.Log("Camera position y is less than " + triggerHeight);
            globalVolume.SetActive(true);
        }
        else
        {
            globalVolume.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("Camera Triggered");
        }
    }
}
