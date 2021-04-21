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
    public GameObject CatBowl;
    public CatBowl catBowlData;

    public RandomPositions RandomPositions;

    private bool isSitting;
    public bool isFed;
    private bool isHunt;

    [SerializeField]
    private float visibleDistance = 5f;
    [SerializeField]
    private float huntSpeed = 4;
    [SerializeField]
    private float walkingSpeed = 2;




    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
        Player = Player.GetComponent<Transform>();
        catBowlData = CatBowl.GetComponent<CatBowl>();
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
        if (!isFed && catBowlData.isHaveFood && Vector3.Distance(transform.position, CatBowl.transform.position) < visibleDistance)
            Hunt(CatBowl.transform);
        else if (!isFed && Vector3.Distance(transform.position, Player.transform.position) < visibleDistance)
            Hunt(Player.transform);
        else
            RandomWalking();
    }

    public void Hunt(Transform huntTarget)
    {
        isHunt = true;
        Agent.speed = huntSpeed;
        Agent.SetDestination(huntTarget.transform.position);
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
