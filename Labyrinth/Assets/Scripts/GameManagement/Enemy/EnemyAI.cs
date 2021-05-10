using System.Collections;
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
    private bool rotate;
    public ParticleSystem dyingEffect;
    System.Random rng = new System.Random();


    // Start is called before the first frame update
    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
        LaserScript = Laser.GetComponent<Laser>();
        Player = GameObject.Find("Player");

        rotate = rng.Next(0, 2) > 0;
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
            transform.Rotate(new Vector3(0, rotate ? -40 : 40, 0) * Time.deltaTime);  
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
            Instantiate(dyingEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
