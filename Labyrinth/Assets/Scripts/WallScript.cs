using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool torchNorth = false;
    public bool torchEast = false;
    public bool torchSouth = false;
    public bool torchWest = false;
    public string naming;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(torchEast || torchNorth || torchSouth || torchWest)
        {
         //   Debug.LogError(naming);
        }
        //Place torch if boolean is true
    }
}
