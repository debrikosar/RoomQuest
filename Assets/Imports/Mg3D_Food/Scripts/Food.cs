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

    public string ShowHint(bool isEnglish)
    {
        if(isEnglish)
            return $"Eat {foodName}";
        else
            return $"Съесть {foodName}";
    }

    public void ToInteract()
    {
        // Добавить ко-во колорией в систему тасков для выполнения Задания

        onEaten?.Invoke();
        GameObject.Destroy(gameObject);
    }
}
