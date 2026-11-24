using NUnit.Framework;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [Header("Current Checkpoint")]
    [SerializeField] GameObject currentCheckpoint;

    [Header("Game Manager")]
    [SerializeField] GameManager gameManager;

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
        currentCheckpoint = checkpoint1;
        currentCheckpoint.GetComponent<CheckpointInstance>().IsCurrentCheckpoint();
    }

    public void PromptCheckpointManager(Collider checkpointTrigger)
    {
        if (checkpointTrigger.gameObject == currentCheckpoint)
        {
            Debug.Log("Checkpoint Triggered");
            currentCheckpoint.GetComponent<CheckpointInstance>().IsPastCheckpoint();
            SetupNextCheckpoint();
            currentCheckpoint.GetComponent<CheckpointInstance>().IsCurrentCheckpoint();
        }
        else
        {
            Debug.Log("Wrong Checkpoint Triggered");
        }
    }

    //I don't know how to automate this.
    public void SetupNextCheckpoint()
    {
        if (currentCheckpoint == checkpoint1 && checkpoint2 != null)
        {
            currentCheckpoint = checkpoint2;
        }
        else if (currentCheckpoint == checkpoint1 && checkpoint2 == null)
        {
            gameManager.EndGame();
        }

        else if (currentCheckpoint == checkpoint2 && checkpoint3 != null)
        {
            currentCheckpoint = checkpoint3;
        }
        else if (currentCheckpoint == checkpoint2 && checkpoint3 == null)
        {
            gameManager.EndGame();
        }

        else if (currentCheckpoint == checkpoint3 && checkpoint4 != null)
        {
            currentCheckpoint = checkpoint4;
        }
        else if (currentCheckpoint == checkpoint3 && checkpoint4 == null)
        {
            gameManager.EndGame();
        }

        else if (currentCheckpoint == checkpoint4 && checkpoint5 != null)
        {
            currentCheckpoint = checkpoint5;
        }
        else if (currentCheckpoint == checkpoint4 && checkpoint5 == null)
        {
            gameManager.EndGame();
        }

        else if (currentCheckpoint == checkpoint5 && checkpoint6 != null)
        {
            currentCheckpoint = checkpoint6;
        }
        else if (currentCheckpoint == checkpoint5 && checkpoint6 == null)
        {
            gameManager.EndGame();
        }

        else if (currentCheckpoint == checkpoint6 && checkpoint7 != null)
        {
            currentCheckpoint = checkpoint7;
        }
        else if (currentCheckpoint == checkpoint6 && checkpoint7 == null)
        {
            gameManager.EndGame();
        }
    }
}
