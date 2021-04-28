using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffButton : MonoBehaviour, IInteract
{
    [SerializeField]
    private Canvas desktopCanvas;

    public string ShowHint(bool isEnglish)
    {
        if(isEnglish)
            return "Press Power Button";
        else
            return "������ ������ �������";
    }

    public void ToInteract()
    {
        desktopCanvas.enabled = !desktopCanvas.enabled;
    }
}
