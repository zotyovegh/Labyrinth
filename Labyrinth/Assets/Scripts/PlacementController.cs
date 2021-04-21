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

    private Transform _selection;

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
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo))
        {
            var selection = hitInfo.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if(selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }

                _selection = selection;
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
