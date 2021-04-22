using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffButton : MonoBehaviour, IInteract
{
    [SerializeField]
    private Canvas desktopCanvas;

    public string ShowHint()
        => "������ ������ �������";

    public void ToInteract()
    {
        desktopCanvas.enabled = !desktopCanvas.enabled;
    }
}
