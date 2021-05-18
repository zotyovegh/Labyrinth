using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public CharacterController controller;
    [SerializeField]
    public GameFinishedController finishedController;
    [SerializeField]
    public float speed = 12f;

    void Update()
    {
        if (GameSetup.isFinished) return;
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cup"))
        {
            if (GameSetup.isSurvival) 
            {
                var currentDifficulty = GameSetup.gameType;

                switch (currentDifficulty)
                {
                    case "easy":
                        GameSetups.SetMedium();
                        break;
                    case "medium":
                        GameSetups.SetHard();
                        break;
                    case "hard":
                        GameSetups.SetExtreme();
                        break;
                    case "extreme":
                    case "custom":
                        OnGameFinished(other.gameObject.tag);
                        break;
                }

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                OnGameFinished(other.gameObject.tag);
            }            
        }else if (other.gameObject.CompareTag("Enemy"))
        {
            //DIED
            OnGameFinished(other.gameObject.tag);
        }
    }

    private void OnGameFinished(string result)
    {
        switch (result)
        {
            case "Cup":
                finishedController.resultText.text = "YOU WON!";
                break;
            case "Enemy":
                finishedController.resultText.text = "GAME OVER!";
                break;
        }

        finishedController.Display();
        Debug.Log("Game finished");
    }
}
