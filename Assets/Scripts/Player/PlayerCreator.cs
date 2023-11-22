using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor;

public class PlayerCreator : MonoBehaviour
{
    public GameObject gameObject;
    public Vector3 spawnPos = new Vector3(0, 2, 0);
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreatePlayer", 0.5f);
    }

    void CreatePlayer()
    {
        GameObject player = PhotonNetwork.Instantiate("Player", spawnPos, Quaternion.identity);
        player.GetComponent<PlayerSetup>().IsLocalPlayer();
    }
}
