using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public bool offline = false;
    public PlayerMovement playerMovement;
    public PlayerInteract playerInteract;
    public PlayerUI playerUI;
    public GameObject playerCamera;

    void Start()
    {
        if (offline)
        {
            IsLocalPlayer();
        }
    }

    //Enables necessary components on the local player
    public void IsLocalPlayer()
    {
        playerMovement.enabled = true;
        playerInteract.enabled = true;
        playerUI.enabled = true;
        playerCamera.SetActive(true);
    }
}
