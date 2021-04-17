using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class CatController : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Animator Anim;
    public Transform Player;

    public RandomPositions RandomPositions;

    private bool isSitting;
    private bool isFed;
    private bool isHunt;

    [SerializeField]
    private float visibleDistance = 7f;
    [SerializeField]
    private float huntSpeed = 4;
    [SerializeField]
    private float walkingSpeed = 2;




    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
        Player = Player.GetComponent<Transform>();
    }

    public void WalkAnim()
    {
        Anim.ResetTrigger("Finish");
        Anim.SetTrigger("Go");
    }

    public void SitAnim()
    {
        Anim.ResetTrigger("Go");
        Anim.SetTrigger("Finish");
    }

    void Update()
    {
        if (!isFed && Vector3.Distance(transform.position, Player.transform.position) < visibleDistance)
            Hunt();
        else
            RandomWalking();
    }

    public void Hunt()
    {
        isHunt = true;
        Agent.speed = huntSpeed;
        Agent.SetDestination(Player.transform.position);
        WalkAnim();
    }

    public void RandomWalking()
    {
        isHunt = false;
        Agent.speed = walkingSpeed;
        if (!Agent.hasPath && !isSitting)
            StartCoroutine(CatWaiting(UnityEngine.Random.Range(4, 10)));
    }

    IEnumerator CatWaiting(float waitingTime)
    {
        isSitting = true;
        SitAnim();
        yield return new WaitForSeconds(waitingTime);
        Agent.SetDestination(RandomPositions.RandomDestination());
        isSitting = false;
        WalkAnim();
    }
}
