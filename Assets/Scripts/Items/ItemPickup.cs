using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [Header("Settings")]
    public float distance = 5f;
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
        origin = playerCamera.position;
        direction = playerCamera.forward;

        Ray ray = new Ray(origin, direction);

        Debug.DrawRay(ray.origin, ray.direction * distance);
    }
}
