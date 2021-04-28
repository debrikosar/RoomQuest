using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    GameObject gameMenu;
    [SerializeField]
    GameObject playerControl;

    [SerializeField]
    List <GameObject> trackedMovableObjects;
    [SerializeField]
    GameObject TaskManager;

    private TasksScript tasksScript;

    private SaveData saveData;
    private SaveData loadData;

    private const string saveFileName = "/SaveData.json";

    void Awake()
    {
        tasksScript = TaskManager.GetComponent<TasksScript>();

        saveData = new SaveData();
        if (File.Exists(Application.persistentDataPath + saveFileName))
            LoadGame();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SummonMenu();
    }

    
    public void SummonMenu()
    {
        SwitchPlayerControl();

        gameMenu.SetActive(gameMenu.activeSelf ? false : true);
    }

    public void SwitchPlayerControl()
    {
        playerControl.GetComponent<PlayerControl>().enabled = !playerControl.GetComponent<PlayerControl>().enabled;
        Cursor.visible = !Cursor.visible;

        if (Cursor.lockState == CursorLockMode.Locked)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void CloseGame() => Application.Quit();

    public void SaveGame()
    {
        saveData.RecordTaks(tasksScript.tasksStatus);
        saveData.RecordMovableObjects(trackedMovableObjects);
        File.WriteAllText(Application.persistentDataPath + saveFileName, JsonConvert.SerializeObject(saveData, Formatting.Indented));
    }

    public void LoadGame()
    {
        loadData = JsonConvert.DeserializeObject<SaveData>(File.ReadAllText(Application.persistentDataPath + saveFileName));

        foreach (GameObject trackedMovableObject in trackedMovableObjects)
        {
            trackedMovableObject.transform.position = loadData.movableObjectsInfo[trackedMovableObject.name].objectPosition;

            trackedMovableObject.transform.rotation = new Quaternion(
                loadData.movableObjectsInfo[trackedMovableObject.name].objectRotationX,
                loadData.movableObjectsInfo[trackedMovableObject.name].objectRotationY,
                loadData.movableObjectsInfo[trackedMovableObject.name].objectRotationZ,
                loadData.movableObjectsInfo[trackedMovableObject.name].objectRotationW);
        }

        tasksScript.tasksStatus = loadData.tasksProgress;
    }
}
