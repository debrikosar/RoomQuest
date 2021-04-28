using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class OutputRemoteTV : MonoBehaviour
{ 
    public GameObject OutputRemoteControlTV;
    public VideoPlayer VideoPlayerTV;
    public GameObject QuadTV;

    private MeshRenderer QuadMeshRenderer;

    public static event Action onTVturnedOn;
    void Start()
    {
        QuadMeshRenderer = QuadTV.GetComponent<MeshRenderer>();
    }

    public void InteractTV()
    {
        RaycastHit hit;
        if (Physics.Raycast(OutputRemoteControlTV.transform.position, OutputRemoteControlTV.transform.forward, out hit))
        {
            if (hit.transform.tag == "TV")
            {
                VideoPlayerTV.enabled = !VideoPlayerTV.enabled;
                QuadMeshRenderer.enabled = !QuadMeshRenderer.enabled;
                onTVturnedOn?.Invoke();
            }
        }
    }
}
