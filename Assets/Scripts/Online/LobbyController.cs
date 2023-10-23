using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyController : MonoBehaviourPunCallbacks
{
    public void JoinGame()
    {
        PhotonNetwork.JoinRandomRoom();
        print("trying to join a room");
    }
}
