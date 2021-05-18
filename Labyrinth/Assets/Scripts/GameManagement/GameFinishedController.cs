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
            switch (GameSetup.gameType)
            {
                case "easy":
                    GameSetups.SetEasy();
                    break;
                case "medium":
                    GameSetups.SetMedium();
                    break;
                case "hard":
                    GameSetups.SetHard();
                    break;
                case "extreme":
                    GameSetups.SetExtreme();
                    break;
                case "custom":
                    GameSetups.savedCustomSetup.InstallSavedCustom();
                    break;
            }
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
