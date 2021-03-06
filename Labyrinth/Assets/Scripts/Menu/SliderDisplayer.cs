using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderDisplayer : MonoBehaviour
{
    [SerializeField]
    public TMPro.TextMeshProUGUI textToUpdate;
    [SerializeField]
    public Slider slider;
    public int infiniteValue;

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
