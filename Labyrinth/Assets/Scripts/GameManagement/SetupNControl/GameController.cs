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
                else if (currentDifficulty.Equals("extreme") || currentDifficulty.Equals("custom")) {  
                    OnGameFinished(other.gameObject.tag); 
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
        if (result.Equals("Cup")) finishedController.resultText.text = "YOU WON!";
        if (result.Equals("Enemy")) finishedController.resultText.text = "GAME OVER!";
        finishedController.Display();
        Debug.Log("Game finished");
    }
}
