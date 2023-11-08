using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerCreator : MonoBehaviour
{
    public Vector3 spawnPos = new Vector3(0, 2, 0);
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreatePlayer", 0.5f);
    }

    void CreatePlayer()
    {
        PhotonNetwork.Instantiate("Player", spawnPos, Quaternion.identity);
    }
}
