using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class CatController : MonoBehaviour
{
    public Camera MainCamera;
    public NavMeshAgent Agent;
    public Animator Anim;
    public RaycastHit hit;
    

    void Start()
    {
        MainCamera = Camera.main;
        Agent = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
    }

    public void StartAnim()
    {
        Anim.ResetTrigger("Finish");
        Anim.SetTrigger("Go");
    }

    public void StopAnim()
    {
        Anim.ResetTrigger("Go");
        Anim.SetTrigger("Finish");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Agent.SetDestination(hit.point);
            }
            StartAnim();
        }

        if (Agent.remainingDistance <= 1 && Agent.remainingDistance > 0)
            StopAnim();
    }
}
