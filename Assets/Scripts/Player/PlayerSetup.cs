using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public bool offline = false;
    public static bool isOffline;
    public PlayerMovement playerMovement;
    public PlayerInteract playerInteract;
    public PlayerUI playerUI;
    public GameObject playerCamera;

    void Start()
    {
        isOffline = offline;
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
