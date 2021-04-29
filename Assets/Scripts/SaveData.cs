using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public List<Task> tasksInfo;
    public Dictionary<string, MovableObject> movableObjectsInfo;

    public SaveData()
    {
        tasksInfo = new List<Task>();
        movableObjectsInfo = new Dictionary<string, MovableObject>();
    }

    public void RecordMovableObjects(List <GameObject> trackedMovableObjects)
    {
        movableObjectsInfo.Clear();
        foreach (GameObject trackedMovableObject in trackedMovableObjects)
            movableObjectsInfo.Add(trackedMovableObject.name, new MovableObject(trackedMovableObject.transform.position, trackedMovableObject.transform.rotation));
    }

    public void RecordTaks(List<Task> tasks)
    {
        tasksInfo = tasks;
    }
}