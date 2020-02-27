﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//状态
public enum EnemyState
{
    idle,
    movement,
    attack
}

public class AI001 : MonoBehaviour
{
    //状态
    public EnemyState CurrentState = EnemyState.idle;
    //玩家
    private Transform player1;
    private Transform player2;
    private Transform player;
    //导航
    private NavMeshAgent agent;
    public AudioClip shootAudio;

 

    private Transform firePosition;
    public GameObject shellPrefab;
    public float shellSpeed = 10;

    public float t1=1f;     //定义一个时间，可以在面板输入，这个时间是从小球发射至小球消失的时间，为2秒时是个距离，4秒是个距离 。                                                                                                                       做个循环(几秒实例化一个)
    private float t2;   




    // Start is called before the first frame update
    void Start()
    {
        t2 = t1;
        agent = GetComponent<NavMeshAgent>();
        player1 = GameObject.FindGameObjectWithTag("Tank2").transform;
        player2 = GameObject.FindGameObjectWithTag("Tank1").transform;
        firePosition = transform.Find("FirePosition");
        player = player1;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 == null && player2 == null)
            return;
        else if (player1 == null)
            player = player2;
        t2 = t2 - Time.deltaTime;
        float distance = Vector3.Distance(player.position, transform.position);
        //判断状态
        switch (CurrentState)
        {
            case EnemyState.idle:
                if(distance>=15)
                {
                    CurrentState = EnemyState.movement;
                }
                //导航停止
                agent.isStopped = true;
                break;
            case EnemyState.movement:
                //追踪状态
                if(distance<15)
                {
                    CurrentState = EnemyState.attack;
                }
                //导航开启
                agent.isStopped = false;
                agent.SetDestination(player.position);
                break;
            case EnemyState.attack:
                {
                    agent.isStopped = true;
                    if (distance<15 && t2 <= 0)
                    {
                        AudioSource.PlayClipAtPoint(shootAudio, transform.position);
                        GameObject go = GameObject.Instantiate(shellPrefab, firePosition.position, firePosition.rotation) as GameObject;
                        go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellSpeed;
                        t2 = t1;
                    }
                    if(distance>=15)
                    {
                        CurrentState = EnemyState.idle;
                    }
                }
                break;
        }
    
    }
}
