using UnityEngine;

public class Laser : MonoBehaviour
{    
    [SerializeField]
    public GameObject nose;

    private LineRenderer _lr;
    public bool enemyfound = false;
    public float timeValue;
    public float timeDefault;
    public bool timeOff = false;

    // Start is called before the first frame update
    void Start()
    {
        _lr = GetComponent<LineRenderer>();
        timeValue = timeDefault;
    }

    // Update is called once per frame
    void Update()
    {
        
        _lr.SetPosition(0, nose.transform.position);
        RaycastHit hit;

        if (Physics.Raycast(nose.transform.position, nose.transform.forward, out hit))
        {
            if (hit.collider)
            {
                if(hit.collider.tag == "Player")
                {
                    enemyfound = true;
                    timeValue = timeDefault;
                }
                
                _lr.SetPosition(1, hit.point);
            }
        }
        else _lr.SetPosition(1, nose.transform.forward*50000);
        Timer();
    }

    void Timer()
    {
        if(timeValue  > 0 && enemyfound && !timeOff)
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
            enemyfound = false;
            
            
        }
    }
}
