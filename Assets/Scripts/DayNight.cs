using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DayNight : MonoBehaviour
{
	public Transform directionalLight;
	//public float fullDay = 120f;
	/*[Range(0, 1)]*/ public float currentTime;

	void Update()
	{
        //currentTime += Time.deltaTime / fullDay;

        //currentTime = 1 / 86400 * (GameTimeSystem.instance.hour * 3600 + GameTimeSystem.instance.minutes * 60 + GameTimeSystem.instance.seconds);

        currentTime = GameTimeSystem.instance.GetTimeForSun();

        //if (currentTime >= 1) currentTime = 0; else if (currentTime < 0) currentTime = 0;

        directionalLight.localRotation = Quaternion.Euler((currentTime * 360f) - 90, 170, 0);
	}
}