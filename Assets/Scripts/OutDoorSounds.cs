using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutDoorSounds : MonoBehaviour
{
    public WindowInteract[] windowsInteract;
    private bool isAnyWindowOpenOrBroken;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        audioSource.Pause();
    }

    public void CheckWindowsBehaviour()
    {
        isAnyWindowOpenOrBroken = false;

        foreach (var window in windowsInteract)
        {
            if (window.isOpen || window.breakableWindow.isBroken)
            {
                isAnyWindowOpenOrBroken = true;
                break;
            }
        }

        if (isAnyWindowOpenOrBroken)
            audioSource.UnPause();         
        else
            audioSource.Pause();      
    }
}
