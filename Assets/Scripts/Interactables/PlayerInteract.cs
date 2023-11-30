using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float distance = 3f;
    public LayerMask layerMask;
    public Transform playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Create ray at the center of the camera
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        //Stores collision information
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, layerMask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Debug.Log(hitInfo.collider.GetComponent<Interactable>().promptmessage);
            }
        }
    }
}
