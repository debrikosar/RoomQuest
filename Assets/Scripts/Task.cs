using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Task
{
    public string taskName;
    public bool taskStatus;

    public Task(string taskName, bool taskStatus)
    {
        this.taskName = taskName;
        this.taskStatus = taskStatus;
    }
}
