using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBowl : MonoBehaviour
{
    public bool isHaveFood;
    public GameObject CatFood;
    public CatController Cat;

    public static event Action onCatFed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CatFood")
        {
            Destroy(other.transform.gameObject);
            CatFood.SetActive(true);
            isHaveFood = true;
            onCatFed?.Invoke();
        }

        if (other.tag == "Cat" && isHaveFood)
        {
            CatFood.SetActive(false);
            isHaveFood = false;
            Cat.isFed = true;
            Cat.Agent.SetDestination(Cat.RandomPositions.RandomDestination());
        }
    }
}
