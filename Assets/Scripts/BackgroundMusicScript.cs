using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    private static BackgroundMusicScript _instance;

    void Awake()
    {
        if (!_instance)
            _instance = this;
        else
        {
            this.gameObject.GetComponent<AudioSource>().volume = _instance.gameObject.GetComponent<AudioSource>().volume;
            Destroy(_instance.gameObject);
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);


        if (PlayerPrefs.HasKey("Music Volume"))
            this.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Music Volume");
    }
}
