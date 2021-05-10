﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent Mob;
    public float currentHealth = 100f;
    private GameObject Player;
    public GameObject Laser;
    private Laser LaserScript;
    public float MobDistanceRun = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
        LaserScript = Laser.GetComponent<Laser>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (LaserScript.timeOff)
        {
            Mob.isStopped = true;
            LaserScript.timeOff = false;
            Mob.ResetPath();
        }
        if (!LaserScript.Enemyfound)
        {
            transform.Rotate(new Vector3(30, 30, 35) * Time.deltaTime);  
        }
        else
        {            
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;
            Mob.SetDestination(newPos);         
        }
    }
    public void ReceiveBullet(float bulletStrength)
    {
        LaserScript.Enemyfound = true;
        currentHealth -= bulletStrength;
        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}