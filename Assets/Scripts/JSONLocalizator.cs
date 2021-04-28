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
    private static JSONLocalizator instance;

    public bool isEnglish;
    public bool isEditing;

    public List<TextMeshProUGUI> localizableObjectsText;
    public Dictionary<string, string> localizedText;

    private const string englishLocalizationFileName = "EnglishLocalization.json";
    private const string russianLocalizationFileName = "RussianLocalization.json";

    private string activeLocalizationFileName;

    private string currentSceneName;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

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

        InitializeTextFields();

        if (isEditing)
            EditLocalizationFile();
        else
            LoadLocalizationFile();
    }

    public void InitializeLocalizationFileName()
    {
        if (isEnglish)
            activeLocalizationFileName = Environment.CurrentDirectory + "/LocalizationFiles/" + currentSceneName + englishLocalizationFileName;
        else
            activeLocalizationFileName = Environment.CurrentDirectory + "/LocalizationFiles/" + currentSceneName + russianLocalizationFileName;
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
    }

    public void LoadLocalizationOnUI()
    {
        foreach (TextMeshProUGUI localizableObjectText in localizableObjectsText)
        {
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
            localizedText.Add(localizableObjectText.name, localizableObjectText.text);
        }
    }

    public void SwitchLocalization(bool isEnglish)
    {
        if (this.isEnglish != isEnglish)
        {
            this.isEnglish = isEnglish;
            InitializeLocalizationFileName();
            LoadLocalizationFile();
        }          
    }
}