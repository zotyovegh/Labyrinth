using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class LevelDisplayer : MonoBehaviour
{
    [SerializeField]
    public TMPro.TextMeshProUGUI displayer;

    private float _fadeTime;
    private bool _fadingIn;
    
    void Start()
    {
        displayer.CrossFadeAlpha(0, 0.0f, false);
        _fadeTime = 0;
        _fadingIn = true;
        if (GameSetup.gameType != null && !GameSetup.gameType.Equals("custom"))
        {
           displayer.text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(GameSetup.gameType.ToLower());
        } 
    }
    
    void Update()
    {
        if (_fadingIn) FadeIn();
        else if (displayer.color.a != 0) displayer.CrossFadeAlpha(0, 0.5f, false);
    }

    private void FadeIn()
    {
        displayer.CrossFadeAlpha(1, 0.5f, false);
        _fadeTime += Time.deltaTime;
        if(displayer.color.a == 1 && _fadeTime > 1.5f)
        {
            _fadingIn = false;
            _fadeTime = 0;
        }
    }
}
