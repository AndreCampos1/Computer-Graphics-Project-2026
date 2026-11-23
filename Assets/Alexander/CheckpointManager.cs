using NUnit.Framework;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [Header("Current Checkpoint")]
    [SerializeField] GameObject CurrentCheckpoint;

    [Header("Checkpoint colliders")]
    [SerializeField] GameObject checkpoint1;
    [SerializeField] GameObject checkpoint2;
    [SerializeField] GameObject checkpoint3;
    [SerializeField] GameObject checkpoint4;
    [SerializeField] GameObject checkpoint5;
    [SerializeField] GameObject checkpoint6;
    [SerializeField] GameObject checkpoint7;


    public void Start()
    {
        CurrentCheckpoint = checkpoint1;
        CurrentCheckpoint.GetComponent<CheckpointInstance>().IsCurrentCheckpoint();
    }

    public void PromptCheckpointManager(Collider checkpointTrigger)
    {
        if (checkpointTrigger.gameObject == CurrentCheckpoint)
        {
            Debug.Log("Checkpoint Triggered");
            CurrentCheckpoint.GetComponent<CheckpointInstance>().IsPastCheckpoint();
            SetupNextCheckpoint();
            CurrentCheckpoint.GetComponent<CheckpointInstance>().IsCurrentCheckpoint();
        }
        else
        {
            Debug.Log("Wrong Checkpoint Triggered");
        }
    }

    //I don't know how to automate this.
    public void SetupNextCheckpoint()
    {
        if (CurrentCheckpoint == checkpoint1)
        {
            CurrentCheckpoint = checkpoint2;
        }
        else if (CurrentCheckpoint == checkpoint2)
        {
            CurrentCheckpoint = checkpoint3;
        }
        else if (CurrentCheckpoint == checkpoint3)
        {
            CurrentCheckpoint = checkpoint4;
        }
        else if (CurrentCheckpoint == checkpoint4)
        {
            CurrentCheckpoint = checkpoint5;
        }
        else if (CurrentCheckpoint == checkpoint5)
        {
            CurrentCheckpoint = checkpoint6;
        }
        else if (CurrentCheckpoint == checkpoint6)
        {
            CurrentCheckpoint = checkpoint7;
        }
    }
}
