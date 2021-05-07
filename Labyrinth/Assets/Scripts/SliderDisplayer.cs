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
        float val = Mathf.RoundToInt(slider.value);
        if (infiniteValue != 0)
        {
            if(val == infiniteValue)
            {
                textToUpdate.text = "∞";
            }
            else
            {
                textToUpdate.text = val + "";
            }
        }
        else
        {
            textToUpdate.text = val + "";
        }
       
    }
}
