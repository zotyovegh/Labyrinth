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

    public GameObject ObjectNorth = null;
    public GameObject ObjectEast = null;
    public GameObject ObjectSouth = null;
    public GameObject ObjectWest = null;

    public GameObject torchPrefab;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (torchSouth && ObjectSouth == null)
        {
            PlaceOnSouth();
        }
        else if (!torchSouth && ObjectSouth != null)
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
        torchPrefab.gameObject.transform.position = transform.position + new Vector3(0, 0, 1);
       torchPrefab.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        ObjectNorth = Instantiate(torchPrefab);
        ObjectNorth.transform.Rotate(35, 0, 0);
    }

    void PlaceOnEast()
    {
        torchPrefab.gameObject.transform.position = transform.position + new Vector3(1, 0, 0);
        torchPrefab.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        ObjectEast = Instantiate(torchPrefab);
        ObjectEast.transform.Rotate(0, 0, -35);
    }

    void PlaceOnSouth()
    {
        torchPrefab.gameObject.transform.position = transform.position + new Vector3(0, 0, -1);
        torchPrefab.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        ObjectSouth = Instantiate(torchPrefab);
        ObjectSouth.transform.Rotate(-35, 0, 0);
    }

    void PlaceOnWest()
    {
        torchPrefab.gameObject.transform.position = transform.position + new Vector3(-1, 0, 0);
        torchPrefab.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        ObjectWest = Instantiate(torchPrefab);
        ObjectWest.transform.Rotate(0, 0, 35);
    }
}
