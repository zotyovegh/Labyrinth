using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class LevelDisplayer : MonoBehaviour
{
    [SerializeField]
    public TMPro.TextMeshProUGUI displayer;

    private float fadeTime;
    private bool fadingIn;

    // Start is called before the first frame update
    void Start()
    {
        displayer.CrossFadeAlpha(0, 0.0f, false);
        fadeTime = 0;
        fadingIn = true;
        if (GameSetup.gameType != null && !GameSetup.gameType.Equals("custom"))
        {
           displayer.text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(GameSetup.gameType.ToLower());
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingIn) FadeIn();
        else if (displayer.color.a != 0) displayer.CrossFadeAlpha(0, 0.5f, false);
    }

    private void FadeIn()
    {
        displayer.CrossFadeAlpha(1, 0.5f, false);
        fadeTime += Time.deltaTime;
        if(displayer.color.a == 1 && fadeTime > 1.5f)
        {
            fadingIn = false;
            fadeTime = 0;
        }
    }
}
