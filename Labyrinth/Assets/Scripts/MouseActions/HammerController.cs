using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    [SerializeField]
    public string selectableTag = "Selectable";
    [SerializeField]
    public float clickType = -1;
    [SerializeField]
    public int destroyDistance = 10;
    [SerializeField]
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
        if (GameSetup.hammerLife <= 0) return;
        var wallScript = wall.GetComponent<WallScript>();
        if (wallScript.isMapEdgeElement) return;
        if (wallScript.objectNorth) DestroyTorchOnWall(wallScript.objectNorth, wallScript);  
        if (wallScript.objectEast) DestroyTorchOnWall(wallScript.objectEast, wallScript);
        if (wallScript.objectSouth) DestroyTorchOnWall(wallScript.objectSouth, wallScript);
        if (wallScript.objectWest) DestroyTorchOnWall(wallScript.objectWest, wallScript);

        wallScript.DestroyWall();
        //sound
        SoundManager.PlaySound("collapse");
        //anim
        animator.SetTrigger("isSwinging");

        GameSetup.hammerLife--;
        if (GameSetup.hammerLife == 0) {
            Destroy(gameObject);                    
        }
    }

    private static void DestroyTorchOnWall(GameObject torch, WallScript wallScript)
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
