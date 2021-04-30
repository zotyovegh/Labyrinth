using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    public string selectableTag = "Selectable";
    public float clickType = -1;
    public int placementDistance = 10;

    void Update()
    {        
        DetectAndAct();        
    }

    private void DetectAndAct()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.gameObject.CompareTag(selectableTag) && hitInfo.distance < placementDistance)
            {
                ReleaseIfClicked();
                var wall = hitInfo.transform.gameObject;
                if (wall != null)
                {
                    if (clickType != -1)
                    {
                        GameObject emptyGO = new GameObject();
                        Transform newTransform = emptyGO.transform;
                        string direction = GetDirection(newTransform, hitInfo);
                        WallScript wallScript = wall.GetComponent<WallScript>();

                        TorchAction(direction, wallScript, clickType == 0 ? false : true);
                        clickType = -1;
                    }
                }
            }
        }
    }

    private void TorchAction(string direction, WallScript wallScript, bool v)
    {
        if (direction == "north")
        {
            wallScript.torchNorth = v;
        }
        else if (direction == "east")
        {
            wallScript.torchEast = v;
        }
        else if (direction == "south")
        {
            wallScript.torchSouth = v;
        }
        else if (direction == "west")
        {
            wallScript.torchWest = v;
        }
    }

    private string GetDirection(Transform transform, RaycastHit hitInfo)
    {
        string direction = null;
        float xAxis = Vector3.Dot(transform.forward, hitInfo.normal);
        float yAxis = Vector3.Dot(transform.right, hitInfo.normal);
        if (xAxis != 0)
        {
            if (xAxis == 1) //NORTH
            {
                direction = "north";
            }
            if (xAxis == -1) //SOUTH
            {
                direction = "south";
            }
        }
        else
        {
            if (yAxis == 1) //EAST
            {
                direction = "east";
            }
            if (yAxis == -1) //WEST
            {
                direction = "west";
            }
        }
        return direction;
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickType = 0;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            clickType = 1;
        }
    }
}
