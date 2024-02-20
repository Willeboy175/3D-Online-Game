using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor;

public class PlayerCreator : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreatePlayer", 0.5f);
    }

    void CreatePlayer()
    {
        if (PhotonNetwork.IsConnected)
        {
            //Instantiates player prefab
            //Runs IsLocalPlayer on the instantiated player prefab
            GameObject player = PhotonNetwork.Instantiate("Player", spawnPos.position, Quaternion.identity);
            player.GetComponent<PlayerSetup>().IsLocalPlayer();
        }
        else
        {
            GameObject player = Instantiate(playerObject, spawnPos.position, Quaternion.identity);
            player.GetComponent<PlayerSetup>().offline = true;
        }
    }
}
