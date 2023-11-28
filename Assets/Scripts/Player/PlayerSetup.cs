using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public bool offline = false;
    public PlayerMovement playerMovement;
    public ItemPickup itemPickup;
    public GameObject playerCamera;

    void Start()
    {
        if (offline)
        {
            IsLocalPlayer();
        }
    }

    public void IsLocalPlayer()
    {
        playerMovement.enabled = true;
        itemPickup.enabled = true;
        playerCamera.SetActive(true);
    }
}
