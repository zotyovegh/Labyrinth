using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderDisplayer : MonoBehaviour
{
    TMPro.TextMeshProUGUI textToUpdate;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
        textToUpdate = GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void valueUpdate(float data)
    {
        textToUpdate.text = Mathf.RoundToInt(data) + "";
    }
}
