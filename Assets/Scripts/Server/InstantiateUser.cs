using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class InstantiateUser : MonoBehaviourPunCallbacks
{

    public override void OnJoinedRoom()
    {
        Spawn();
    }

    void Spawn()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(5, 1, -150), Quaternion.identity);
    }
}