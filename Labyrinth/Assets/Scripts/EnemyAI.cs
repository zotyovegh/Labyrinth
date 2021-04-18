using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent Mob;

    public GameObject Player;
    public GameObject Laser;
    private Laser LaserScript;

    public float MobDistanceRun = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
        LaserScript = Laser.GetComponent<Laser>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!LaserScript.Enemyfound)
        {
            transform.Rotate(new Vector3(30, 30, 35) * Time.deltaTime);
        }else
        {
            float distance = Vector3.Distance(transform.position, Player.transform.position);

            if(distance < MobDistanceRun)
                {
                    Vector3 dirToPlayer = transform.position - Player.transform.position;
                    Vector3 newPos = transform.position - dirToPlayer;
                     Mob.SetDestination(newPos);
            }
        }
        

        //if detected
         
    }
}
