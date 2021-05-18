using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField]
    public int selectedItem = 0;
    
    void Start()
    {
        Change();
    }

    private void Change()
    {
        var i = 0;
        foreach(Transform item in transform)
        {
            if (i == selectedItem)
            {
                item.gameObject.SetActive(true);
                GameSetup.itemInHand = item.gameObject.name;
            }
            else item.gameObject.SetActive(false);
            i++;
        }
    }
    
    void Update()
    {
        var previous = selectedItem;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedItem >= transform.childCount - 1) selectedItem = 0;
            else selectedItem++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedItem <= 0) selectedItem = transform.childCount - 1;
            else selectedItem--;
        }

        if(previous != selectedItem)
        {
            Change();
        }
    }
}
