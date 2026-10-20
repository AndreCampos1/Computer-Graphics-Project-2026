using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;

public class CameraControll : MonoBehaviour
{
    private RaycastHit[] hits; //Array with the hits from raycast
    private List<GameObject> previousHits = new List<GameObject>(); //Objects hit by the raycast that needs to become opaque again
    private Vector3 rayDir; //Direction of the raycast

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject mainCamera;

    void Update()
    {
        int playerLayer = player.layer; 
        int cameraLayer = mainCamera.layer;

        int ignoreLayer = ~((1 << playerLayer) | (1 << cameraLayer)); //Gets the player and camera layer and invert it, using all other layers

        rayDir = Vector3.Normalize(player.transform.position - mainCamera.transform.position);
        float distance = Vector3.Distance(player.transform.position, mainCamera.transform.position); //Distance between camera and player, so the raycast ends at player position

        hits = Physics.RaycastAll(mainCamera.transform.position, rayDir, distance, ignoreLayer);

        foreach(GameObject obj in previousHits) //Sets previous hits back to opaque
        {
            if (obj != null)
            {
                SetTransparency(obj, 1f);
            }
        }
        previousHits.Clear();

        foreach (RaycastHit hit in hits) //Sets new hits to the new alpha
        {
            GameObject hitObj = hit.transform.gameObject;
            SetTransparency(hitObj, 0.1f);
            previousHits.Add(hitObj);
        }
    }

    void SetTransparency(GameObject obj, float alpha)
    {
        Renderer render = obj.GetComponent<Renderer>();
        Color color = render.material.color;
        render.material.color = new Color(color.r, color.g, color.b, alpha);
    }
}
