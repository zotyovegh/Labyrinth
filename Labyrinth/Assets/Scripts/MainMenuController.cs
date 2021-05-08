﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI sizeSlider;
    public TMPro.TextMeshProUGUI safeDistanceSlider;
    public TMPro.TextMeshProUGUI torchAmountSlider;
    public TMPro.TextMeshProUGUI enemyAmountSlider;
    public TMPro.TextMeshProUGUI hammerLifeSlider;
    public TMPro.TextMeshProUGUI bulletAmountSlider;

    public void PlaySurvival()
    {
        GameSetup.isSurvival = true;
        GameSetups.SetEasy();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayEasy()
    {
        GameSetup.isSurvival = false;
        GameSetups.SetEasy();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayMedium()
    {
        GameSetup.isSurvival = false;
        GameSetups.SetMedium();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayHard()
    {
        GameSetup.isSurvival = false;
        GameSetups.SetHard();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayExtreme()
    {
        GameSetup.isSurvival = false;
        GameSetups.SetExtreme();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayCustom()
    {
        GameSetup.isSurvival = false;
        GameSetups.SetCustom(sizeSlider.text, safeDistanceSlider.text, enemyAmountSlider.text, torchAmountSlider.text, bulletAmountSlider.text, hammerLifeSlider.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
