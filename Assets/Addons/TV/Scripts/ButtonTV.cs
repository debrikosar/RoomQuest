using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTV : MonoBehaviour, IInteract
{
    [SerializeField]
    private OutputRemoteTV outputRemoteScipt;

    public string ShowHint(bool isEnglish)
    {
        if(isEnglish)
            return "Press Remote Button"; 
        else
            return "Нажать кнопку на пульте";
    }

    public void ToInteract()
    {
        outputRemoteScipt.InteractTV();
    }
}
