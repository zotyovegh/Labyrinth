using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderDisplayer : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI _textToUpdate;
    [SerializeField]
    public Slider slider;
    public int infiniteValue;
    // Start is called before the first frame update

    void Start()
    {
        _textToUpdate = GetComponent<TMPro.TextMeshProUGUI>(); 
        slider.onValueChanged.AddListener(delegate { OnValueChanged(); });
    }

    public void OnValueChanged()
    {
        if (infiniteValue != 0)
        {
            if(slider.value == infiniteValue)
            {
                _textToUpdate.text = "∞";
            }
            else
            {
                _textToUpdate.text = slider.value + "";
            }
        }
        else
        {
            _textToUpdate.text = slider.value + "";
        }
       
    }
}
