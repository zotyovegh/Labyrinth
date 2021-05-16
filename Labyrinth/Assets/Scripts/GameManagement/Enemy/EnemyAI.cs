using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    public float currentHealth = 100f;
    [SerializeField]
    public GameObject Laser;
    [SerializeField]
    public float MobDistanceRun = 4.0f;    
    [SerializeField]
    public ParticleSystem dyingEffect;

    private System.Random rng = new System.Random();
    private bool rotate;
    private Laser LaserScript;
    private GameObject Player;
    private NavMeshAgent Mob;

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
            //sound
            SoundManager.PlaySound("die");
            Instantiate(dyingEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
