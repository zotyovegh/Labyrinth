using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderDisplayer : MonoBehaviour
{
    TMPro.TextMeshProUGUI textToUpdate;
    // Start is called before the first frame update
    void Start()
    {
        textToUpdate = GetComponent<TMPro.TextMeshProUGUI>();
        
    }

    public void valueUpdate(float value)
    {
        textToUpdate.text = Mathf.RoundToInt(value) + "";
    }
}
