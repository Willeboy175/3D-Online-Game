using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public float distance = 3f;
    public LayerMask layerMask;
    public Transform playerCamera;
    private PlayerUI playerUI;

    private PlayerControls controls;
    private InputAction look;

    // Start is called before the first frame update
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
    }

    void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Empties promptText
        //Create ray at the center of the camera
        //Stores collision information
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hitInfo;

        Debug.DrawRay(ray.origin, ray.direction * distance);

        //Checks if the ray has hit a valid object and stores it
        if (Physics.Raycast(ray, out hitInfo, distance, layerMask))
        {
            //Checks if object has Interactable component
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                //Saves to Interactable variable
                //Updates the promptText
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptmessage);

                //If player presses interact key
                if (Input.GetKeyDown(SettingsController.keyBinds["interact"]))
                {
                    interactable.BaceInteract();
                }
            }
        }
    }
}
