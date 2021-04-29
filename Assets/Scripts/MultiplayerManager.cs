using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerManager : Photon.PunBehaviour
{
    public GameObject MpPlayer;

    private void Awake()
    {
        Debug.Log("Joined room");
        MpPlayer = PhotonNetwork.Instantiate("PcForMP", new Vector3(70, 24, 42), Quaternion.identity, 0);
    }

    public void PlayerExit()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("MainMenu");
    }

    public override void OnMasterClientSwitched(PhotonPlayer newMasterClient)
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("MainMenu");
    }
}
