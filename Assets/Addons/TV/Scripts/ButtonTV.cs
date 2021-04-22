using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTV : MonoBehaviour, IInteract
{
    [SerializeField]
    private OutputRemoteTV outputRemoteScipt;

    public string ShowHint()
        => "������ ������ �� ������";

    public void ToInteract()
    {
        outputRemoteScipt.InteractTV();
    }
}
