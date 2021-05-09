using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cup"))
        {
            if (GameSetup.isSurvival)
            {
                string currentDifficulty = GameSetup.gameType;

                if (currentDifficulty.Equals("easy")) {
                    GameSetups.SetMedium();
                } 
                else if (currentDifficulty.Equals("medium")) {
                    GameSetups.SetHard();
                } 
                else if (currentDifficulty.Equals("hard")) {
                    GameSetups.SetExtreme();
                }                
                else if (currentDifficulty.Equals("extreme")) {  
                    OnGameFinished(); 
                }
              
                Debug.Log(currentDifficulty + " " + GameSetup.gameType);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                OnGameFinished();
            }
            
        }
    }

    private void OnGameFinished()
    {
        Debug.Log("Game finished");
    }
}
