using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderDisplayer : MonoBehaviour
{
    TMPro.TextMeshProUGUI textToUpdate;
    public Slider slider;
    public int infiniteValue;
    public float value;
    // Start is called before the first frame update

    void Start()
    {
        textToUpdate = GetComponent<TMPro.TextMeshProUGUI>(); 
        slider.onValueChanged.AddListener(delegate { OnValueChanged(); });
    }

    public void OnValueChanged()
    {
        if (infiniteValue != 0)
        {
            if(slider.value == infiniteValue)
            {
                textToUpdate.text = "∞";
            }
            else
            {
                textToUpdate.text = slider.value + "";
            }
        }
        else
        {
            textToUpdate.text = slider.value + "";
        }
       
    }
}
