using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IInteract
{
    [SerializeField]
    private string foodName;

    [SerializeField]
    private float coloriesCount;

    public string ShowHint()
        => $"������ {foodName}";

    public void ToInteract()
    {
        // �������� ��-�� �������� � ������� ������ ��� ���������� �������

        GameObject.Destroy(gameObject);
    }
}
