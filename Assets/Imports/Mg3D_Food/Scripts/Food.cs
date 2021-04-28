using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IInteract
{
    [SerializeField]
    private string foodName;

    [SerializeField]
    private float coloriesCount;

    public static event Action onEaten;

    public string ShowHint()
        => $"������ {foodName}";

    public void ToInteract()
    {
        // �������� ��-�� �������� � ������� ������ ��� ���������� �������

        onEaten?.Invoke();
        GameObject.Destroy(gameObject);
    }
}
