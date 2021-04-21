using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    public GameObject torch;
    public KeyCode hotkey = KeyCode.Space;

    private GameObject currentTorch;
    public Material highlightMaterial;
    public Material defaultMaterial;
    public string selectableTag = "Selectable";

    private GameObject selectedWall;
    //private WallScript wallScript; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* HandleNewTorchHotkey();

        if(currentTorch != null)
        { }*/
  //  ReleaseIfClicked();

            MoveTorchToMouse();
        
       
    }

    private void HandleNewTorchHotkey()
    {
        if (Input.GetKeyDown(hotkey))
        {
            if(currentTorch != null)
            {
                Destroy(currentTorch);
            }
            else
            {
                currentTorch = Instantiate(torch);
            }
        }
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
                    WallScript wallScript = wall.GetComponent<WallScript>();
                    wallScript.torchEast = true;
                }
                selectedWall = wall;
            }            
        }       
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentTorch = null;
        }
    }
}
