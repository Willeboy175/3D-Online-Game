using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject playerCamera;

    public void IsLocalPlayer()
    {
        playerMovement.enabled = true;
        playerCamera.SetActive(true);
    }
}
