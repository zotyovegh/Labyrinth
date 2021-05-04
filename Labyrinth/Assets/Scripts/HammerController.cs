using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    public string selectableTag = "Selectable";
    public float clickType = -1;
    public int destroyDistance = 10;

    void Update()
    {
        DetectAndBreak();
    }

    private void DetectAndBreak()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.gameObject.CompareTag(selectableTag) && hitInfo.distance < destroyDistance)
            {
                ReleaseIfClicked();
                var wall = hitInfo.transform.gameObject;
                if (wall != null)
                {
                    if (clickType != -1)
                    {
                        DestroyWall(wall);
                        clickType = -1;
                    }
                }
            }
        }
    }

    private void DestroyWall(GameObject wall)
    {        
        WallScript wallScript = wall.GetComponent<WallScript>();
        if (wallScript.isMapEdgeElement) return;        
        if (wallScript.ObjectNorth) Destroy(wallScript.ObjectNorth);
        if (wallScript.ObjectEast) Destroy(wallScript.ObjectEast);
        if (wallScript.ObjectSouth) Destroy(wallScript.ObjectSouth);
        if (wallScript.ObjectWest) Destroy(wallScript.ObjectWest);
        Destroy(wall);
    }

    private void ReleaseIfClicked()
    {

        if (Input.GetMouseButtonDown(0))
        {
            clickType = 0;
        }
    }
}
