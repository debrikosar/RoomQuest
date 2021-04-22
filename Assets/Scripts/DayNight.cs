using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DayNight : MonoBehaviour
{
	public Transform directionalLight;
    [Range(0, 1)] public float currentTime;

	void Update()
	{
        currentTime = GameTimeSystem.instance.GetTimeForSun();
        directionalLight.localRotation = Quaternion.Euler((currentTime * 360f) - 90f, 195.993f, -146.348f);
	}
}