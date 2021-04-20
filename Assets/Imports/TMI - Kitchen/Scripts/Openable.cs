using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : MonoBehaviour, IInteract
{
    [SerializeField]
    private Animator animator;
    private bool isOpen;
    private string hintMessage;

    public void Start()
    {
        animator = GetComponentInParent<Animator>();    
    }

    public void ShowHint()
    {
        throw new System.NotImplementedException();
    }

    public void ToInteract()
    {
        if (!isOpen)
        {
            animator.SetTrigger("Open");
            isOpen = true;
        }
        else
        {
            animator.SetTrigger("Close");
            isOpen = false;
        }
    }
}
