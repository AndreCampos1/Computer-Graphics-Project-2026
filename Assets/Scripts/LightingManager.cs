using UnityEngine;

public class LightingManager : MonoBehaviour
{
    public Renderer ballRenderer;
    public Material ballMaterial;

    private Color originalBaseColor;
    private Color originalRimColor;
    private float originalAmbientIntensity;
    private float originalSmoothness;
    private float originalMetallic;
    private float originalRefIntensity;
    private float originalDistortionStrength;

    void Start()
    {
        ballRenderer = this.GetComponent<Renderer>();
        ballMaterial = ballRenderer.material;
        originalBaseColor = ballMaterial.GetColor("_BaseColor");
        originalRimColor = ballMaterial.GetColor("_RimColor");
        originalSmoothness = ballMaterial.GetFloat("_Smoothness");
        originalMetallic = ballMaterial.GetFloat("_Metallic");
        originalRefIntensity = ballMaterial.GetFloat("_ReflectionIntensity");
        originalDistortionStrength = ballMaterial.GetFloat("_DistortionStrength");
        originalAmbientIntensity = ballMaterial.GetFloat("_AmbientIntensity");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SetLightingState(1); // No Lighting
        if (Input.GetKeyDown(KeyCode.Alpha2)) SetLightingState(2); // Ambient Only
        if (Input.GetKeyDown(KeyCode.Alpha3)) SetLightingState(3); // Specular Only
        if (Input.GetKeyDown(KeyCode.Alpha4)) SetLightingState(4); // Ambient + Specular
        if (Input.GetKeyDown(KeyCode.Alpha5)) SetLightingState(5); // Ambient + Specular + Rim
        if (Input.GetKeyDown(KeyCode.Alpha6)) SetLightingState(6); // Ambient + Specular + Rim + Reflection
        if (Input.GetKeyDown(KeyCode.Alpha7)) SetLightingState(7); // Everything + Distortion
    }

    void SetLightingState(int state)
    {
        ballMaterial.SetColor("_BaseColor", Color.black);
        ballMaterial.SetFloat("_Smoothness", 0f);
        ballMaterial.SetFloat("_Metallic", 0f);
        ballMaterial.SetColor("_RimColor", Color.black);
        ballMaterial.SetFloat("_DistortionStrength", 0f);
        ballMaterial.SetFloat("_AmbientIntensity", 0f);
        ballMaterial.SetFloat("_ReflectionIntensity", 0f);

        switch (state)
        {
            case 1: //No lighting
                Debug.Log("State 1: No Lighting (Black)");
                break;
            
            case 2: //Ambient Only
                Debug.Log("State 2: Ambient Only");
                ballMaterial.SetColor("_BaseColor", originalBaseColor);
                ballMaterial.SetFloat("_AmbientIntensity", originalAmbientIntensity);
                break;

            case 3: //Specular Only
                Debug.Log("State 3: Specular Only");
                ballMaterial.SetColor("_BaseColor", Color.black); // No diffuse
                ballMaterial.SetFloat("_Smoothness", 1f); //Max specular
                break;

            case 4: //Ambient + Specular + Diffuse
                Debug.Log("State 4: Ambient + Specular");
                ballMaterial.SetColor("_BaseColor", originalBaseColor);
                ballMaterial.SetFloat("_Smoothness", 1f);
                ballMaterial.SetFloat("_Metallic", originalMetallic);
                ballMaterial.SetFloat("_AmbientIntensity", originalAmbientIntensity);

                break;
            
            case 5: // Ambient + Specular + Rim
                Debug.Log("State 5: Ambient + Specular + Rim Light");
                ballMaterial.SetColor("_BaseColor", originalBaseColor);
                ballMaterial.SetFloat("_Smoothness", originalSmoothness);
                ballMaterial.SetFloat("_Metallic", originalMetallic);
                ballMaterial.SetColor("_RimColor", originalRimColor);
                ballMaterial.SetFloat("_AmbientIntensity", originalAmbientIntensity);

                break;

            case 6: //Ambient + Specular + Rim Light + Reflection
                Debug.Log("State 6: Ambient + Specular + Rim Light + Reflection");
                ballMaterial.SetColor("_BaseColor", originalBaseColor);
                ballMaterial.SetFloat("_Smoothness", originalSmoothness);
                ballMaterial.SetFloat("_Metallic", originalMetallic);
                ballMaterial.SetColor("_RimColor", originalRimColor);
                ballMaterial.SetFloat("_AmbientIntensity", originalAmbientIntensity);
                ballMaterial.SetFloat("_ReflectionIntensity", originalRefIntensity);
                break;
            
            case 7: // Everything + Distortion
                Debug.Log("State 7: Everything + Distortion");
                ballMaterial.SetColor("_BaseColor", originalBaseColor);
                ballMaterial.SetFloat("_Smoothness", originalSmoothness);
                ballMaterial.SetFloat("_Metallic", originalMetallic);
                ballMaterial.SetColor("_RimColor", originalRimColor);
                ballMaterial.SetFloat("_AmbientIntensity", originalAmbientIntensity);
                ballMaterial.SetFloat("_ReflectionIntensity", originalRefIntensity);
                ballMaterial.SetFloat("_DistortionStrength", originalDistortionStrength);
                break;
        }
    }
}
