using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinishedController : MonoBehaviour
{
    public GameObject gamePlayScreen;
   public void Display()
    {
        Cursor.lockState = CursorLockMode.None;
        GameSetup.isFinished = true;
        gamePlayScreen.SetActive(false);
        gameObject.SetActive(true);
    }

}
