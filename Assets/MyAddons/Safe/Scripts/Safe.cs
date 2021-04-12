using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour, IInteract
{
    [SerializeField]
    private bool isOpen;

    [SerializeField]
    private bool isLocked;

    [SerializeField]
    private AudioSource safeAudioSource;

    [SerializeField]
    private AudioClip doorLockedAudioClip;

    [SerializeField]
    private AudioClip doorOpenAudioClip;

    [SerializeField]
    private AudioClip doorCloseAudioClip;

    private Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ShowHint()
    {

    }

    public void ToInteract()
    {
        if (isLocked)
        {
            anim.SetTrigger("Locked");
            safeAudioSource.PlayOneShot(doorLockedAudioClip);
        }
        else
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
    }
}
