using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositions : MonoBehaviour
{
    public List<Vector3> positions = new List<Vector3>();
    
    public Vector3 RandomDestination()
    {
        if (positions.Count != 0)
            return positions[Random.Range(0, positions.Count)];
        else
            throw new System.Exception("Массив случайных позиций пуст");
    }
}
