using System;
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

    public static event Action onWindowOpen;
    public static event Action onWindowClose;

    public void Start()
    {
        anim = GetComponentInParent<Animator>();
        breakableWindow = GetComponent<BreakableWindow>();
    }

    public string ShowHint(bool isEnglish)
    {
        if (!isOpen)
        {
            if (isEnglish)
                return "Open Window";
            else
                return "������� ����";
        }
        else
        {
            if (isEnglish)
                return "Close Window";
            else
                return "������� ����";
        }
    }

    public void ToInteract()
    {
        if (isOpen)
        {
            onWindowClose?.Invoke();
            anim.SetTrigger("Close");
            isOpen = false;
        }
        else
        {
            onWindowOpen?.Invoke();
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
