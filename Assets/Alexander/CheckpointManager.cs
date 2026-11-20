using NUnit.Framework;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    //Material stuff
    private Material lastMaterial;
    private Material currentMaterial;

    [Header("Current Checkpoint")]
    [SerializeField] Collider CurrentCheckpoint;

    [Header("Checkpoints")]
    [SerializeField] GameObject checkpoint1;
    [SerializeField] GameObject checkpoint2;
    [SerializeField] GameObject checkpoint3;
    [SerializeField] GameObject checkpoint4;
    [SerializeField] GameObject checkpoint5;
    [SerializeField] GameObject checkpoint6;
    [SerializeField] GameObject checkpoint7;


    public void Start()
    {
        CurrentCheckpoint = checkpoint1.GetComponent<Collider>();
        currentMaterial = CurrentCheckpoint.GetComponent<Renderer>().material;
        PrepareCurrentMaterial();
    }

    public void OnTriggerEnter(Collider CurrentCheckpoint)
    {
        if (CurrentCheckpoint.CompareTag("Player"))
        {
            PrepareLastMaterial();
            SetupNextCheckpoint();
            PrepareCurrentMaterial();
        }
            
    }

    //I don't know how to automate this.
    public void SetupNextCheckpoint()
    {
        if (CurrentCheckpoint == checkpoint1.GetComponent<Collider>())
        {
            CurrentCheckpoint = checkpoint2.GetComponent<Collider>();
        }
        else if (CurrentCheckpoint == checkpoint2.GetComponent<Collider>())
        {
            CurrentCheckpoint = checkpoint3.GetComponent<Collider>();
        }
        else if (CurrentCheckpoint == checkpoint3.GetComponent<Collider>())
        {
            CurrentCheckpoint = checkpoint4.GetComponent<Collider>();
        }
        else if (CurrentCheckpoint == checkpoint4.GetComponent<Collider>())
        {
            CurrentCheckpoint = checkpoint5.GetComponent<Collider>();
        }
        else if (CurrentCheckpoint == checkpoint5.GetComponent<Collider>())
        {
            CurrentCheckpoint = checkpoint6.GetComponent<Collider>();
        }
        else if (CurrentCheckpoint == checkpoint6.GetComponent<Collider>())
        {
            CurrentCheckpoint = checkpoint7.GetComponent<Collider>();
        }
    }

    public void PrepareCurrentMaterial()
    {
        currentMaterial.SetInt("_IsCurrent", 1);
    }

    public void PrepareLastMaterial()
    {
        lastMaterial.SetInt("_IsPast", 1);
    }
}
