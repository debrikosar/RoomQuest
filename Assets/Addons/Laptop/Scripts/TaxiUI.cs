using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaxiUI : MonoBehaviour
{
    public TextMeshProUGUI InfoText;
    public TMP_InputField[] inputFields;
    private string[] savedInputFieldsData;

    private bool isSomethingSaved;
    private string correctInputs = "123123";

    private string correctInfoText = "Такси успешно заказано!";
    private string uncorrectInfoText = "Данные карты введены неверно!" ;

    public static event Action OnCorrectPasswordInput;
    public static event Action OnTaxiAppOpened;

    public void Start()
    {
        
    }

    public void IconButtonClick()
    {
        OnTaxiAppOpened?.Invoke();
        this.gameObject.SetActive(true);
        if (isSomethingSaved)
            for (var i = 0; i < savedInputFieldsData.Length; i++)
                inputFields[i].text = savedInputFieldsData[i];
        else
            for (var i = 0; i < inputFields.Length; i++)
                inputFields[i].text = "";
    }

    public void CloseButtonClick()
        => this.gameObject.SetActive(false);

    public void SaveButtonClick()
    {
        savedInputFieldsData = new string[inputFields.Length];
        for (var i = 0; i < inputFields.Length; i++)
            savedInputFieldsData[i] = inputFields[i].text;
        isSomethingSaved = true;
    }

    public void OrderButtonClick()
    {
        string userInputs = default;
        foreach (var field in inputFields)
            userInputs += field.text;

        if (userInputs == correctInputs)
            TryOrder(true, correctInfoText);
        else
            TryOrder(false, uncorrectInfoText);
    }

    public void TryOrder(bool correct, string info)
    {
        if (correct)
        {
            InfoText.text = info;
            TaskCompleted();
        }
        else
            InfoText.text = info;
    }

    public void TaskCompleted()
    {
        OnCorrectPasswordInput?.Invoke();
        Debug.Log("Задание выполнено");
    }
}
