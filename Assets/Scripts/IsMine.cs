using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMine : Photon.PunBehaviour
{
    void Start()
    {
        if (photonView.isMine)
        {
            gameObject.GetComponent<PlayerControl>().enabled = true;
            gameObject.GetComponentInChildren<Camera>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
