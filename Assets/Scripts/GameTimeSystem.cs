using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeSystem : MonoBehaviour
{
    public static GameTimeSystem instance = null;

    //-- set start time 00:00
    public int minutes = 0;
    public int hour = 0;

    //-- time speed factor
    public float timeSpeed = 1.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster

    //-- internal vars
    public int seconds;
    public float msecs;

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
        InitializeManager();
    }

    private void InitializeManager()
    {
        msecs = 0.0f;
        seconds = 0;
    }



    void Update()
    {
        //-- calculate time
        msecs += Time.deltaTime * timeSpeed;
        if (msecs >= 1.0f)
        {
            msecs -= 1.0f;
            seconds++;
            if (seconds >= 60)
            {
                seconds = 0;
                minutes++;
                if (minutes > 60)
                {
                    minutes = 0;
                    hour++;
                    if (hour >= 24)
                        hour = 0;
                }
            }
        }
    }
}
