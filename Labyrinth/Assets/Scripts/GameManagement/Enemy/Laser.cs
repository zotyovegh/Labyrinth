using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{    
    [SerializeField]
    public GameObject Nose;

    private LineRenderer lr;
    public bool Enemyfound = false;
    public float timeValue;
    public float timeDefault;
    public bool timeOff = false;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        timeValue = timeDefault;
    }

    // Update is called once per frame
    void Update()
    {
        
        lr.SetPosition(0, Nose.transform.position);
        RaycastHit hit;

        if (Physics.Raycast(Nose.transform.position, Nose.transform.forward, out hit))
        {
            if (hit.collider)
            {
                if(hit.collider.tag == "Player")
                {
                    Enemyfound = true;
                    timeValue = timeDefault;
                }
                
                lr.SetPosition(1, hit.point);
            }
        }
        else lr.SetPosition(1, Nose.transform.forward*50000);
        Timer();
    }

    void Timer()
    {
        if(timeValue  > 0 && Enemyfound && !timeOff)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            if(timeValue <= 0)
            {
               timeOff = true;
            }
            timeValue = timeDefault;
            Enemyfound = false;
            
            
        }
    }
}
