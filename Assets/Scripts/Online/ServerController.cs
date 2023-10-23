using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ServerController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject startbutton;

    // Start is called before the first frame update
    void Start()
    {
        startbutton.SetActive(false);
        PhotonNetwork.ConnectUsingSettings();
        print("Connecting...");
    }

    public override void OnConnectedToMaster()
    {
        startbutton.SetActive(true);
        PhotonNetwork.AutomaticallySyncScene = true;
        print("Connected to server in " + PhotonNetwork.CloudRegion + ".");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
