using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    [SerializeField]
    public string selectableTag = "Selectable";
    [SerializeField]
    public float clickType = -1;
    [SerializeField]
    public int placementDistance = 10;
    [SerializeField]
    public Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

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
                if (wall == null) return;
                if (clickType == -1) return;
                var emptyGO = new GameObject();
                Transform newTransform = emptyGO.transform;
                var direction = GetDirection(newTransform, hitInfo);
                var wallScript = wall.GetComponent<WallScript>();

                TorchAction(direction, wallScript, clickType != 0);
                clickType = -1;
            }
        }
    }

    private void TorchAction(string direction, WallScript wallScript, bool v)
    {
        if (v && GameSetup.torchAmount == 0 && GameSetup.isFinished) return;
            switch (direction)
            {
                case "north":
                    wallScript.torchNorth = v;
                    break;
                case "east":
                    wallScript.torchEast = v;
                    break;
                case "south":
                    wallScript.torchSouth = v;
                    break;
                case "west":
                    wallScript.torchWest = v;
                    break;
            }        

        //anim
        animator.SetTrigger("isPlacing");
    }

    private string GetDirection(Transform transform, RaycastHit hitInfo)
    {
        string direction = null;
        var xAxis = Vector3.Dot(transform.forward, hitInfo.normal);
        var yAxis = Vector3.Dot(transform.right, hitInfo.normal);
        if (xAxis != 0)
        {
            switch (xAxis)
            {
                //NORTH
                case 1:
                    direction = "north";
                    break;
                //SOUTH
                case -1:
                    direction = "south";
                    break;
            }
        }
        else
        {
            switch (yAxis)
            {
                //EAST
                case 1:
                    direction = "east";
                    break;
                //WEST
                case -1:
                    direction = "west";
                    break;
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
