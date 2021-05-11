using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinishedController : MonoBehaviour
{
    public GameObject gamePlayScreen;
   public void Display()
    {
        gamePlayScreen.SetActive(false);
        gameObject.SetActive(true);
    }

}
