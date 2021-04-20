using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WindowInteract : MonoBehaviour, IInteract
{
    public bool isOpen;

    [SerializeField]
    private Animator anim;

    public BreakableWindow breakableWindow;
    public UnityEvent onBehaviourChanged;

    public void Start()
    {
        anim = GetComponentInParent<Animator>();
        breakableWindow = GetComponent<BreakableWindow>();
    }

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

        WindowBehaviourChange();
    }

    public void WindowBehaviourChange()
    {
        onBehaviourChanged?.Invoke();
    }
}
