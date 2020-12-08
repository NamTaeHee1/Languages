using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public string GameVersion = "1.0";
    public string NickName = "Player";

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void Init()
    {
        PhotonNetwork.GameVersion = GameVersion;
        PhotonNetwork.NickName = NickName;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("InGameScene");
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 2 }, null);
    }
}
