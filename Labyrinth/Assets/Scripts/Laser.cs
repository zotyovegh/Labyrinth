using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lr;
    public GameObject Enemy;
    public bool Enemyfound = false;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {        
        lr.SetPosition(0, Enemy.transform.position);
        RaycastHit hit;

        if (Physics.Raycast(Enemy.transform.position, Enemy.transform.forward, out hit))
        {
            if (hit.collider)
            {
                if(hit.collider.tag == "Player")
                {
                    //    Debug.LogError(hit.collider.tag);
                    Enemyfound = true;
                }
                
                lr.SetPosition(1, hit.point);
            }
        }
        else lr.SetPosition(1, Enemy.transform.forward*50000);
    }
}
