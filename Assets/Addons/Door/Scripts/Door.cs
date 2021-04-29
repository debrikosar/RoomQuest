using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteract
{
    [SerializeField]
    private bool isOpen;

    [SerializeField]
    private bool isLocked;

    [SerializeField]
    private AudioSource doorAudioSource;

    [SerializeField]
    private AudioClip doorLockedAudioClip;

    [SerializeField]
    private AudioClip doorOpenAudioClip;

    [SerializeField]
    private AudioClip doorCloseAudioClip;

    private Animator anim;

    public static event Action OnCheckiIfDoorIsLocked;

    public void Start()
    {
        anim = GetComponentInParent<Animator>();
        TasksScript.OnTasksFinished += openLock;
    }

    public string ShowHint(bool isEnglish)
    {
        if (isEnglish)
            return "Open";
        else
            return "Открыть";
    }

    public void ToInteract()
    {
        OnCheckiIfDoorIsLocked?.Invoke();

        if (isLocked)
        {
            anim.SetTrigger("Locked");
            doorAudioSource.PlayOneShot(doorLockedAudioClip);
        }
        else
        {
            if (isOpen)
            {
                anim.SetTrigger("Close");
                isOpen = false;
                doorAudioSource.PlayOneShot(doorCloseAudioClip);
            }
            else
            {
                anim.SetTrigger("Open");
                isOpen = true;
                doorAudioSource.PlayOneShot(doorOpenAudioClip);
            }
        }
    }

    public void openLock()
    {
        isLocked = false;
    }

    private void OnDestroy()
    {
        TasksScript.OnTasksFinished -= openLock;
    }
}
