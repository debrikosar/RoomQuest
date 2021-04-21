using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTV : MonoBehaviour, IInteract
{
    [SerializeField]
    private OutputRemoteTV outputRemoteScipt;

    public void ShowHint()
    {
        
    }

    public void ToInteract()
    {
        outputRemoteScipt.InteractTV();
    }
}
