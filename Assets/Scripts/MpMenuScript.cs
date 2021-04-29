using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MpMenuScript : MonoBehaviour
{
    [SerializeField]
    GameObject gameMenu;

    [SerializeField]
    private MultiplayerManager MpManager;

    [SerializeField]
    private PlayerControl playerControl;

    public UnityEvent onPlayerExit;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SummonMenu();
    }


    public void SummonMenu()
    {
        playerControl = MpManager.MpPlayer.GetComponent<PlayerControl>();
        SwitchPlayerControl();

        gameMenu.SetActive(gameMenu.activeSelf ? false : true);
    }

    public void SwitchPlayerControl()
    {
        playerControl.GetComponent<PlayerControl>().enabled = !playerControl.GetComponent<PlayerControl>().enabled;
        Cursor.visible = !Cursor.visible;

        if (Cursor.lockState == CursorLockMode.Locked)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void CloseGame()
    {
        onPlayerExit?.Invoke();
    }
}
