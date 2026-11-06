using UnityEngine;

public class FogController : MonoBehaviour
{
    [SerializeField] bool EnableFog = true;

    [SerializeField] Color FogColor = Color.gray;
    [SerializeField] float MaxFogDensity = 0.05f; 
    [SerializeField] float FogTransitionSeconds = 0.5f;
    private bool isPlayerInFogZone = false;
    private float fogTransitionPercent;

    //To debug, switch this to public and watch the value in the inspector.
    private float CurrentFogDensity = 0f;

    private void Start()
    {
        RenderSettings.fog = EnableFog;
        RenderSettings.fogColor = FogColor;
        fogTransitionPercent = (1/FogTransitionSeconds)*MaxFogDensity;
    }

    //If the player enters a trigger collider, fade in fog. If the player exits the trigger collider, fade out fog.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInFogZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInFogZone = false;
        }
    }

    private void Update()
    {
        if (isPlayerInFogZone)
        {
            RenderSettings.fogDensity = Mathf.MoveTowards(RenderSettings.fogDensity, MaxFogDensity, fogTransitionPercent*Time.deltaTime);
            CurrentFogDensity = RenderSettings.fogDensity;
        }
        else
        {
            RenderSettings.fogDensity = Mathf.MoveTowards(RenderSettings.fogDensity, 0, fogTransitionPercent*Time.deltaTime);
            CurrentFogDensity = RenderSettings.fogDensity;
        }
    }
}
