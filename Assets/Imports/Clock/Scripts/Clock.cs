using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour
{
    GameObject pointerSeconds;
    GameObject pointerMinutes;
    GameObject pointerHours;

    void Start()
    {
        pointerSeconds = transform.Find("rotation_axis_pointer_seconds").gameObject;
        pointerMinutes = transform.Find("rotation_axis_pointer_minutes").gameObject;
        pointerHours = transform.Find("rotation_axis_pointer_hour").gameObject;
    }


    void Update()
    {
        //-- calculate pointer angles
        float rotationSeconds = (360.0f / 60.0f) * GameTimeSystem.instance.seconds;
        float rotationMinutes = (360.0f / 60.0f) * GameTimeSystem.instance.minutes;
        float rotationHours = ((360.0f / 12.0f) * GameTimeSystem.instance.hour) + ((360.0f / (60.0f * 12.0f)) * GameTimeSystem.instance.minutes);

        //-- draw pointers
        pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
        pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
        pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);

    }
}
