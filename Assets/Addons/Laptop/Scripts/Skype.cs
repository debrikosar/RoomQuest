using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Skype : MonoBehaviour
{
    [SerializeField]
    private GameObject skypePanel;

    [SerializeField]
    public TextMeshProUGUI inputMessage;

    [SerializeField]
    private Sprite skypeSprite2;

    private Image skypeImage;

    private string rightMessage;

    void Start()
    {
        skypeImage = skypePanel.GetComponent<Image>();
        //gt = GetComponent<Text>();
    }

    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                if (inputMessage.text.Length != 0)
                {
                    inputMessage.text = inputMessage.text.Substring(0, inputMessage.text.Length - 1);
                }
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                //print("User entered their name: " + gt.text);
                MessageEnter();
            }
            else
            {
                inputMessage.text += c;
            }
        }
    }

    public void SwitchSkypePanel()
    {
            skypePanel.SetActive(!skypePanel.activeSelf);
    }

    public void MessageEnter()
    {
        if (inputMessage.text == rightMessage)
            skypeImage.sprite = skypeSprite2;
        else
            ShowHint();
    }

    public void ShowHint()
    {

    }
}
