using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool torchNorth = false;
    public bool torchEast = false;
    public bool torchSouth = false;
    public bool torchWest = false;

    public GameObject ObjectNorth = null ;
    public GameObject ObjectEast = null;
    public GameObject ObjectSouth = null;
    public GameObject ObjectWest = null;

    public GameObject wallPrefab;

    public string naming;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(torchSouth && ObjectSouth == null)
        {
            PlaceOnSouth();
        }else if(!torchSouth && ObjectSouth != null)
        {
            Destroy(ObjectSouth);
        }

        if (torchEast && ObjectEast == null)
        {
            PlaceOnEast();
        }
        else if (!torchEast && ObjectEast != null)
        {
            Destroy(ObjectEast);
        }

        if (torchNorth && ObjectNorth == null)
        {
            PlaceOnNorth();
        }
        else if (!torchNorth && ObjectNorth != null)
        {
            Destroy(ObjectNorth);
        }

        if (torchWest && ObjectWest == null)
        {
            PlaceOnWest();
        }
        else if (!torchWest && ObjectWest != null)
        {
            Destroy(ObjectWest);
        }
    }

    void PlaceOnNorth()
    {
        wallPrefab.gameObject.transform.position = transform.position + new Vector3(0, 0, 1);
        ObjectNorth = Instantiate(wallPrefab);
    }

    void PlaceOnEast()
    {
        wallPrefab.gameObject.transform.position = transform.position + new Vector3(1, 0, 0);
        ObjectEast = Instantiate(wallPrefab);
    }

    void PlaceOnSouth()
    {
        wallPrefab.gameObject.transform.position = transform.position + new Vector3(0, 0, -1);
        ObjectSouth = Instantiate(wallPrefab);
    }

    void PlaceOnWest()
    {
        wallPrefab.gameObject.transform.position = transform.position + new Vector3(-1, 0, 0);
        ObjectWest = Instantiate(wallPrefab);
    }
}
