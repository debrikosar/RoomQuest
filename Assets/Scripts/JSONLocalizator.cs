using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JSONLocalizator : MonoBehaviour
{
    public bool isEnglish;
    public bool isEditing;

    public List<TextMeshProUGUI> localizableObjectsText;
    public Dictionary<string, string> localizedText;
    public Dictionary<string, string> localizedBoard;
    public Dictionary<string, string> localizedHints;

    private const string englishLocalizationFileName = "EnglishLocalization.json";
    private const string russianLocalizationFileName = "RussianLocalization.json";

    private string activeLocalizationFileName;
    private string activeLocalizationBoardFileName;

    private string currentSceneName;

    private static JSONLocalizator _instance;

    void Awake()
    {
        if (!_instance)
            _instance = this;
        else
        {
            isEnglish = _instance.isEnglish;
            Destroy(_instance.gameObject);
            _instance = this;
        }


        DontDestroyOnLoad(this.gameObject);

        if (PlayerPrefs.HasKey("LocalizationPref"))
            isEnglish = PlayerPrefs.GetInt("LocalizationPref") == 1? true : false;

        InitializeLocalizator();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        if (isEditing)
        {
            InitializeLocalizationFileName();
            EditLocalizationFile();
            isEditing = !isEditing;
        }

    }

    public void InitializeLocalizator()
    {
        currentSceneName = SceneManager.GetActiveScene().name;

        InitializeLocalizationFileName();

        localizedText = new Dictionary<string, string>();
        localizedBoard = new Dictionary<string, string>();

        InitializeTextFields();

        if (isEditing)
            EditLocalizationFile();
        else
            LoadLocalizationFile();
    }

    public void InitializeLocalizationFileName()
    {
        if (isEnglish)
        {
            activeLocalizationFileName = Application.dataPath + "/StreamingAssets/LocalizationFiles/" + currentSceneName + englishLocalizationFileName;
            activeLocalizationBoardFileName = Application.dataPath + "/StreamingAssets/LocalizationFiles/Board" + englishLocalizationFileName;
        }
        else
        {
            activeLocalizationFileName = Application.dataPath + "/StreamingAssets/LocalizationFiles/" + currentSceneName + russianLocalizationFileName;
            activeLocalizationBoardFileName = Application.dataPath + "/StreamingAssets/LocalizationFiles/Board" + russianLocalizationFileName;
        }            
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeLocalizator();
    }

    public void EditLocalizationFile()
    {
        SaveLocalizationDataFromUI();
        SaveLocalizationData();
    }

    public void LoadLocalizationFile()
    {
        LoadLocalizationData();
        LoadLocalizationOnUI();
    }

    public void InitializeTextFields()
    {
        localizableObjectsText = new List<TextMeshProUGUI>(Resources.FindObjectsOfTypeAll(typeof(TextMeshProUGUI)) as TextMeshProUGUI[]);
    }

    public void LoadLocalizationData()
    {
        localizedText = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(activeLocalizationFileName));
        localizedBoard = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(activeLocalizationBoardFileName));
    }

    public void LoadLocalizationOnUI()
    {
        foreach (TextMeshProUGUI localizableObjectText in localizableObjectsText)
        {
            if (localizableObjectText.name != "HintText" && localizableObjectText.name != "Placeholder" && localizableObjectText.name != "TimeText")
                localizableObjectText.text = localizedText[localizableObjectText.name];
        }
    }

    public void SaveLocalizationData()
    {
        File.WriteAllText(activeLocalizationFileName, JsonConvert.SerializeObject(localizedText, Formatting.Indented));
    }

    public void SaveLocalizationDataFromUI()
    {
        localizedText.Clear();

        foreach (TextMeshProUGUI localizableObjectText in localizableObjectsText)
        {
            if(localizableObjectText.name != "HintText" && localizableObjectText.name != "Placeholder" && localizableObjectText.name != "TimeText")
                localizedText.Add(localizableObjectText.name, localizableObjectText.text);
        }
    }

    public void SwitchLocalization(bool isEnglish)
    {
        if (this.isEnglish != isEnglish)
        {
            PlayerPrefs.SetInt("LocalizationPref", isEnglish? 1 : 0);
            this.isEnglish = isEnglish;
            InitializeLocalizationFileName();
            LoadLocalizationFile();
        }          
    }
}
