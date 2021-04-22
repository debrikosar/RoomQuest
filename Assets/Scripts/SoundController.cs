using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    private static SoundController instance;
    private AudioSource[] soundSources;

    public float soundVolume;

    void Start()
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

        FindAllSoundSources();
        ChangeVolumeOfAllSoundSources();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindAllSoundSources();
        ChangeVolumeOfAllSoundSources();
    }

    public void FindAllSoundSources()
    {
        soundSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    }

    public void ChangeVolumeOfAllSoundSources()
    {
        foreach (AudioSource soundSource in soundSources.Where(soundSource => soundSource.name != "BackgroundMusic"))
            soundSource.volume = soundVolume;
    }
}
