using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDetect : MonoBehaviour
{
    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       // lr.SetPosition(0, transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider) //.tag = "Player"......
            {
               // lr.SetPosition(1, hit.point);
            }
        }
       // else lr.SetPosition(1, transform.forward * 5000);
    }
}
