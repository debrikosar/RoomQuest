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
        MpPlayer = PhotonNetwork.Instantiate("PcForMP", new Vector3(54.7f, 25.8f, 39.25f), Quaternion.identity, 0);
    }

    public void PlayerExit()
    {
        PhotonNetwork.LeaveRoom();
        MpPlayer.GetComponent<PlayerControl>().enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }

    public override void OnMasterClientSwitched(PhotonPlayer newMasterClient)
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("MainMenu");
    }
}
