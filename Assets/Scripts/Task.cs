using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Task : ScriptableObject
{
    public string taskName;
    public string taskDescription;
    public bool taskStatus;
}
