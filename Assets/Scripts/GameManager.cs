using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeToFinish = 300f;
    public float timeElpased;

    void Start()
    {
        timeElpased = Time.deltaTime;
    }

    void Update()
    {
        if (timeToFinish > 0)
        {
            timeToFinish -= Time.deltaTime;
        }
        if (timeElpased >= timeToFinish)
        {
            Debug.Log("You Lost!");
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You won!");
            Time.timeScale = 0;
        }
    }
}
