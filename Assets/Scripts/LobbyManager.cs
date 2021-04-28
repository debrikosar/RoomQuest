using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LobbyManager : Photon.PunBehaviour
{
    public TextMeshProUGUI LogText;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("v.1");
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        PhotonNetwork.LoadLevel("CoopScene");
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("CoopScene");
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Log("Join room fail");
    }

    private void Log(string message)
    {
        LogText.text = message;
    }
}
