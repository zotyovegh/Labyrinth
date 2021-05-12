using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFinishedController : MonoBehaviour
{
    public GameObject gamePlayScreen;
    public TMPro.TextMeshProUGUI resultText;
    public void Display()
    {
        Cursor.lockState = CursorLockMode.None;
        GameSetup.isFinished = true;
        gamePlayScreen.SetActive(false);
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        if (GameSetup.isSurvival)
        {
            GameSetups.SetEasy();
        }
        else if (GameSetup.gameType == null) Debug.Log("Testing");
        else
        {
            if (GameSetup.gameType.Equals("easy")) GameSetups.SetEasy();
            if (GameSetup.gameType.Equals("medium")) GameSetups.SetMedium();
            if (GameSetup.gameType.Equals("hard")) GameSetups.SetHard();
            if (GameSetup.gameType.Equals("extreme")) GameSetups.SetExtreme();
            if (GameSetup.gameType.Equals("custom")) GameSetups.savedCustomSetup.InstallSavedCustom();
        }

        GameSetup.isFinished = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        GameSetup.isFinished = false;
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
