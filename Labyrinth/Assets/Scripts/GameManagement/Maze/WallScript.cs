using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public bool isMapEdgeElement = false;

    public bool torchNorth = false;
    public bool torchEast = false;
    public bool torchSouth = false;
    public bool torchWest = false;

    public GameObject objectNorth = null;
    public GameObject objectEast = null;
    public GameObject objectSouth = null;
    public GameObject objectWest = null;

    public GameObject torchPrefab;
    public GameObject torchInHand;

    public ParticleSystem collapseEffect;

    void Start()
    {
        torchInHand = GameObject.Find("TorchInHand");
    }
    
    void Update()
    {        
        if (torchSouth && objectSouth == null)
        {
            if (GameObject.Find("TorchInHand") != null && GameSetup.torchAmount != 0)
            {
                PlaceOnSouth();
                HandleTorchPlacement();
            }                  
        }
        else if (!torchSouth && objectSouth != null)
        {
            HandleTorchDestroy();
            Destroy(objectSouth);
        }

        if (torchEast && objectEast == null)
        {
            if (GameObject.Find("TorchInHand") != null && GameSetup.torchAmount != 0)
            {
                PlaceOnEast();
                HandleTorchPlacement();
            }           
        }
        else if (!torchEast && objectEast != null)
        {
            HandleTorchDestroy();
            Destroy(objectEast);
        }

        if (torchNorth && objectNorth == null)
        {
            if (GameObject.Find("TorchInHand") != null && GameSetup.torchAmount != 0)
            {
                PlaceOnNorth();
                HandleTorchPlacement();
            }                      
        }
        else if (!torchNorth && objectNorth != null)
        {
            HandleTorchDestroy();
            Destroy(objectNorth);
        }

        if (torchWest && objectWest == null)
        {
            if (GameObject.Find("TorchInHand") != null && GameSetup.torchAmount != 0)
            {
                PlaceOnWest();
                HandleTorchPlacement();
            }                       
        }
        else if (!torchWest && objectWest != null)
        {
            HandleTorchDestroy();
            Destroy(objectWest);
        }
    }

    internal void DestroyWall()
    {
        Instantiate(collapseEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void HandleTorchPlacement()
    {
        //sound
        SoundManager.PlaySound("placeTorch");
        GameSetup.torchAmount--;
        if (GameSetup.torchAmount == 0)  torchInHand.SetActive(false); 
    }

    private void HandleTorchDestroy()
    {
        //sound
        SoundManager.PlaySound("destroyTorch");
        if (GameSetup.torchAmount == 0) torchInHand.SetActive(true);  
        GameSetup.torchAmount++;
    }

    private void PlaceOnNorth()
    {
        torchPrefab.gameObject.transform.position = transform.position + new Vector3(0, 0, 1);
       torchPrefab.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        objectNorth = Instantiate(torchPrefab);
        objectNorth.transform.Rotate(35, 0, 0);
    }

    private void PlaceOnEast()
    {
        torchPrefab.gameObject.transform.position = transform.position + new Vector3(1, 0, 0);
        torchPrefab.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        objectEast = Instantiate(torchPrefab);
        objectEast.transform.Rotate(0, 0, -35);
    }

    private void PlaceOnSouth()
    {
        torchPrefab.gameObject.transform.position = transform.position + new Vector3(0, 0, -1);
        torchPrefab.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        objectSouth = Instantiate(torchPrefab);
        objectSouth.transform.Rotate(-35, 0, 0);
    }

    private void PlaceOnWest()
    {
        torchPrefab.gameObject.transform.position = transform.position + new Vector3(-1, 0, 0);
        torchPrefab.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        objectWest = Instantiate(torchPrefab);
        objectWest.transform.Rotate(0, 0, 35);
    }
}
