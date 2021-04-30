using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public GameObject NotificationPanel;

    public GameObject duckyTheDuck;

    public GameObject soundContollerObject;
    private SoundController soundContoller;

    public GameObject soundVolumeSlider;
    private Slider soundSlider;

    public AudioSource musicSource;
    public GameObject musicVolumeSlider;
    private Slider musicSlider;

    private Vector3 posOffset;
    private Vector3 tempPos;

    public float bounceAmplitude = 0.1f;
    public float bounceFrequency = 1f;

    private const string saveFileName = "/SaveData.json";

    // Start is called before the first frame update
    void Start()
    {
        musicSlider = musicVolumeSlider.GetComponent<Slider>();
        soundSlider = soundVolumeSlider.GetComponent<Slider>();

        soundContoller = soundContollerObject.GetComponent<SoundController>();

        musicSlider.value = musicSource.volume;
        soundSlider.value = soundContoller.soundVolume;

        posOffset = duckyTheDuck.transform.position;
    }

    private void Update()
    {
        BounceDucky();
    }

    public void DeleteSaves()
    {
        File.Delete(Application.persistentDataPath + saveFileName);
        SummonNotification();
    }

    public void SummonNotification()
    {
        NotificationPanel.SetActive(NotificationPanel.activeSelf ? false : true);
    }

    public void ChangeMusicVolume()
    {
        PlayerPrefs.SetFloat("Music Volume", musicSlider.value);
        musicSource.volume = musicSlider.value;
    }

    public void ChangeSoundVolume()
    {
        soundContoller.soundVolume = soundSlider.value;
        soundContoller.ChangeVolumeOfAllSoundSources();
    }

    public void BounceDucky()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * bounceFrequency) * bounceAmplitude;

        duckyTheDuck.transform.position = tempPos;
    }
}
