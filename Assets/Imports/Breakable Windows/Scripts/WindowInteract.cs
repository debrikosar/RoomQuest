using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowInteract : MonoBehaviour, IInteract
{
    private bool isOpen;

    [SerializeField]
    private Animator anim;
    
    public void ShowHint()
    {
        throw new System.NotImplementedException();
    }

    public void ToInteract()
    {
        if (isOpen)
        {
            anim.SetTrigger("Close");
            isOpen = false;
        }   
        else
        {
            anim.SetTrigger("Open");
            isOpen = true;
        }
    }
}
