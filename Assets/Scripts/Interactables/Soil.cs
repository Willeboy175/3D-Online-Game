using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : Interactable
{
    public Transform spawnPos;
    public GameObject crop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        if (PlayerSetup.isOffline)
        {
            Instantiate(crop, spawnPos);
        }
        else
        {
            PhotonNetwork.Instantiate("Crop", spawnPos.position, spawnPos.rotation);
        }
        
        Debug.Log("Interacted with " + gameObject.name);
    }
}
