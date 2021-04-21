using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour
{
    private TextMeshProUGUI time;

    void Start()
    {
        time = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        time.text = $"{GameTimeSystem.instance.hour}:{GameTimeSystem.instance.minutes}:{GameTimeSystem.instance.seconds}";
    }
}
