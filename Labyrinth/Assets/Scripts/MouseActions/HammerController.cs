using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    public string selectableTag = "Selectable";
    public float clickType = -1;
    public int destroyDistance = 10;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

    }

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
            if (hitInfo.transform.gameObject.CompareTag(selectableTag) && hitInfo.distance < destroyDistance && !GameSetup.isFinished)
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
        if(GameSetup.hammerLife > 0)
        {
            WallScript wallScript = wall.GetComponent<WallScript>();
            if (wallScript.isMapEdgeElement) return;
            if (wallScript.ObjectNorth) DestroyTorchOnWall(wallScript.ObjectNorth, wallScript);  
            if (wallScript.ObjectEast) DestroyTorchOnWall(wallScript.ObjectEast, wallScript);
            if (wallScript.ObjectSouth) DestroyTorchOnWall(wallScript.ObjectSouth, wallScript);
            if (wallScript.ObjectWest) DestroyTorchOnWall(wallScript.ObjectWest, wallScript);

            wallScript.DestroyWall();
            //anim
             animator.SetTrigger("isSwinging");

            GameSetup.hammerLife--;
            if (GameSetup.hammerLife == 0) {
                Destroy(gameObject);                    
            }
        }
        
    }

    private void DestroyTorchOnWall(GameObject torch, WallScript wallScript)
    {
        Destroy(torch);
        GameSetup.torchAmount++;
        wallScript.torchInHand.SetActive(true);
    }

    private void ReleaseIfClicked()
    {

        if (Input.GetMouseButtonDown(0))
        {
            clickType = 0;
        }
    }
}
