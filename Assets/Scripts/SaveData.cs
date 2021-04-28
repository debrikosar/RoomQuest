using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public List<Task> tasksInfo;
    public Dictionary<string, MovableObject> movableObjectsInfo;
    public Dictionary<string, bool> tasksProgress;

    public SaveData()
    {
        tasksInfo = new List<Task>();
        movableObjectsInfo = new Dictionary<string, MovableObject>();
        tasksProgress = new Dictionary<string, bool>();
    }

    public void RecordMovableObjects(List <GameObject> trackedMovableObjects)
    {
        movableObjectsInfo.Clear();
        foreach (GameObject trackedMovableObject in trackedMovableObjects)
            movableObjectsInfo.Add(trackedMovableObject.name, new MovableObject(trackedMovableObject.transform.position, trackedMovableObject.transform.rotation));
    }

    public void RecordTaks(Dictionary<string, bool> tasksProgress)
    {
        this.tasksProgress = tasksProgress;
    }
}