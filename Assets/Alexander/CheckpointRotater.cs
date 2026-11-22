using UnityEngine;

public class CheckpointRotater : MonoBehaviour
{
    public GameObject Label;
    public GameObject backLabel;
    [SerializeField] public float rotationSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        Label.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        backLabel.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
