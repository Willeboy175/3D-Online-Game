using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    int maxPlayers = 4;

    public void JoinGame()
    {
        PhotonNetwork.JoinRandomRoom();
        print("trying to join a room");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("Can't find room!");
        CreateRoom();
    }

    void CreateRoom()
    {
        print("GET A ROOM!");
        int rng = Random.Range(0, 100000);
        RoomOptions options = new RoomOptions()
        {
            IsOpen = true,
            IsVisible = true,
            MaxPlayers = (byte)maxPlayers
        };
        PhotonNetwork.CreateRoom("Room" + rng, options);
    }
}
