using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IInteract
{
    [SerializeField]
    private string foodName;

    [SerializeField]
    private float coloriesCount;

    public void ShowHint()
    {
        throw new System.NotImplementedException();
    }

    public void ToInteract()
    {
        // Добавить ко-во колорией в систему тасков для выполнения Задания

        GameObject.Destroy(gameObject);
    }
}
