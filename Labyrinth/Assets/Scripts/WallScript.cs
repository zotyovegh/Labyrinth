using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isMapEdgeElement = false;

    public bool torchNorth = false;
    public bool torchEast = false;
    public bool torchSouth = false;
    public bool torchWest = false;

    public GameObject ObjectNorth = null;
    public GameObject ObjectEast = null;
    public GameObject ObjectSouth = null;
    public GameObject ObjectWest = null;

    public GameObject torchPrefab;
    public GameObject torchInHand;

    void Start()
    {
        torchInHand = GameObject.Find("TorchInHand");
    }

    // Update is called once per frame
    void Update()
    {        
        if (torchSouth && ObjectSouth == null)
        {
            if (GameObject.Find("TorchInHand") != null && GameSetup.torchAmount != 0)
            {
                PlaceOnSouth();
                HandleTorchPlacement();
            }                  
        }
        else if (!torchSouth && ObjectSouth != null)
        {
            HandleTorchDestroy();
            Destroy(ObjectSouth);
        }

        if (torchEast && ObjectEast == null)
        {
            if (GameObject.Find("TorchInHand") != null && GameSetup.torchAmount != 0)
            {
                PlaceOnEast();
                HandleTorchPlacement();
            }           
        }
        else if (!torchEast && ObjectEast != null)
        {
            HandleTorchDestroy();
            Destroy(ObjectEast);
        }

        if (torchNorth && ObjectNorth == null)
        {
            if (GameObject.Find("TorchInHand") != null && GameSetup.torchAmount != 0)
            {
                PlaceOnNorth();
                HandleTorchPlacement();
            }                      
        }
        else if (!torchNorth && ObjectNorth != null)
        {
            HandleTorchDestroy();
            Destroy(ObjectNorth);
        }

        if (torchWest && ObjectWest == null)
        {
            if (GameObject.Find("TorchInHand") != null && GameSetup.torchAmount != 0)
            {
                PlaceOnWest();
                HandleTorchPlacement();
            }                       
        }
        else if (!torchWest && ObjectWest != null)
        {
            HandleTorchDestroy();
            Destroy(ObjectWest);
        }
    }

    private void HandleTorchPlacement()
    {
        GameSetup.torchAmount--;
        if (GameSetup.torchAmount == 0)  torchInHand.SetActive(false); 
    }

    private void HandleTorchDestroy()
    {
        if (GameSetup.torchAmount == 0) torchInHand.SetActive(true);  
        GameSetup.torchAmount++;
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
