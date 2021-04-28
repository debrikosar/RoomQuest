using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour, IInteract
{
    [SerializeField]
    private AudioSource safeAudioSource;

    [SerializeField]
    private AudioClip doorOpenAudioClip;

    [SerializeField]
    private AudioClip doorCloseAudioClip;
    
    [Space]
    [SerializeField]
    private Canvas safeUI;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private PlayerControl playerControl;

    [Space]
    [SerializeField]
    private bool isOpen;

    [SerializeField]
    private bool isLocked;

    private string userInputCode;

    [SerializeField]
    private string rigthInputCode = "1234";

    public static event Action OnSafeOpened;

    public string ShowHint(bool isEnglish)
    {
        if (!isOpen)
        {
            if(isEnglish)
                return "Input password";
            else
                return "¬вести пароль";
        }
        else
        {
            if (isEnglish)
                return "Open safe";
            else
                return "ќткрыть сейф";
        }
    }

    public void SwitchCanvasEnabled()
    {
        safeUI.enabled = !safeUI.enabled;
        playerControl.enabled = !playerControl.enabled;
        Cursor.visible = !Cursor.visible;

        if (Cursor.lockState == CursorLockMode.Locked)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void ToInteract()
    {
        if (isLocked)
            SwitchCanvasEnabled();
        else
        {
            Open();
            OnSafeOpened?.Invoke();
        }
    }

    public void Open()
    {
        if (isOpen)
        {
            anim.SetTrigger("Close");
            isOpen = false;
            safeAudioSource.PlayOneShot(doorCloseAudioClip);
        }
        else
        {
            anim.SetTrigger("Open");
            isOpen = true;
            safeAudioSource.PlayOneShot(doorOpenAudioClip);
        }
    }

    public void ButtonPressed(string num)
        => userInputCode += num;

    public void OpenButtonPressed()
    {
        if (userInputCode == rigthInputCode)
        {
            isLocked = false;
        }
        userInputCode = default;

        SwitchCanvasEnabled();
    }
}
