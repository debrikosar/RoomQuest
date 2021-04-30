using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    private AudioSource[] soundSources;

    public float soundVolume;

    private static SoundController _instance;

    void Awake()
    {
        if (!_instance)
            _instance = this;
        else
        {
            soundVolume = _instance.soundVolume;
            Destroy(_instance.gameObject);
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        InitializeSounds();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeSounds();
    }

    public void InitializeSounds()
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
        foreach (AudioSource soundSource in soundSources)
            if (soundSource != null && soundSource.name != "BackgroundMusic")
                soundSource.volume = soundVolume;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
