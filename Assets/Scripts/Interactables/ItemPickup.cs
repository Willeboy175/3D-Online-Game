using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [Header("Settings")]
    public float distance = 5f;
    public LayerMask layerMask;
    public Transform playerCamera;

    private Vector3 origin;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(SettingsController.keyBinds["interact"]))
        {
            Interact();
        }
    }

    void Interact()
    {
        origin = playerCamera.position;
        direction = playerCamera.forward;

        Ray ray = new Ray(origin, direction);
        if (Physics.Raycast(ray, distance, layerMask))
        {
            print("raycast hit");
        }

        Debug.DrawRay(ray.origin, ray.direction * distance);
    }
}
