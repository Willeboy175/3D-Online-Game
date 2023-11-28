using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ServerController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject startbutton;
    [SerializeField]
    GameObject connectingText;

    // Start is called before the first frame update
    void Start()
    {
        startbutton.SetActive(false);
        connectingText.SetActive(true);
        PhotonNetwork.ConnectUsingSettings();
        print("Connecting...");
    }

    public override void OnConnectedToMaster()
    {
        startbutton.SetActive(true);
        connectingText.SetActive(false);
        PhotonNetwork.AutomaticallySyncScene = true;
        print("Connected to server in " + PhotonNetwork.CloudRegion + ".");
    }
}
