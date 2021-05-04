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
                        Destroy(wall);

                        clickType = -1;
                    }
                }
            }
        }
    }

    private void ReleaseIfClicked()
    {

        if (Input.GetMouseButtonDown(0))
        {
            clickType = 0;
        }
    }
}
