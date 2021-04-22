using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    public GameObject torch;
    public KeyCode hotkey = KeyCode.Space;

    public string selectableTag = "Selectable";
    public float clickType = -1;

    private GameObject selectedWall;

    void Start()
    {
        
    }

    void Update()
    {

       /* if(currentTorch != null)
        { }*/
  //  ReleaseIfClicked();

            MoveTorchToMouse();
        ReleaseIfClicked();


    }

    private void MoveTorchToMouse()
    {
        if (selectedWall != null)
        {
            var wall = selectedWall;
            WallScript wallScript = wall.GetComponent<WallScript>();
            wallScript.torchEast = false;
            selectedWall = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo))
        {            
            if (hitInfo.transform.gameObject.CompareTag(selectableTag))
            {
                var wall = hitInfo.transform.gameObject;                
                if(wall != null)
                {
                    if(clickType != -1)
                    {
                        string direction = GetDirection(transform, hitInfo);
                        Debug.Log(clickType);
                        WallScript wallScript = wall.GetComponent<WallScript>();
                        
                        TorchAction(direction, wallScript, clickType == 0 ? false : true);
                        clickType = -1;
                    }   
                }
                selectedWall = wall;
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
        float fwdBack = Vector3.Dot(transform.forward, hitInfo.normal);
        float right = Vector3.Dot(transform.right, hitInfo.normal);
        if (fwdBack != 0)
        {
            if(fwdBack == 1) //NORTH
            {
                direction = "north";
            }
            if (fwdBack == -1) //SOUTH
            {
                direction = "south";
            }
        }
        else
        {
            if (right == 1) //EAST
            {
                direction = "east";                
            }
            if(right == -1) //WEST
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
        }else if (Input.GetMouseButtonDown(1))
        {
            clickType = 1;
        }
    }
}
