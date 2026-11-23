using UnityEngine;

public class CheckpointInstance : MonoBehaviour
{
    [Header("CheckpointManagement")]
    public Collider checkpointTrigger;
    private CheckpointManager checkpointManager;

    [Header("Label rotation")]
    public GameObject Label;
    public GameObject backLabel;
    [SerializeField] public float rotationSpeed = 50f;

    [Header("Checkpoint Materials")]
    public Material checkpointMaterial;

    private void Start()
    {
        checkpointManager = GameObject.Find("Checkpoints folder").GetComponent<CheckpointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Label.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        backLabel.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkpointManager.PromptCheckpointManager(checkpointTrigger);
        }
    }

    public void IsCurrentCheckpoint()
    {
        checkpointMaterial.SetInt("_IsCurrent", 1);
    }

    public void IsPastCheckpoint()
    {
        checkpointMaterial.SetInt("_IsPast", 1);
    }
}
