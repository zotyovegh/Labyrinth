using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip collapse, die, placeTorch, destroyTorch, shoot;
    static AudioSource audioSource;


    void Start()
    {
        collapse = Resources.Load<AudioClip>("collapse");
        die = Resources.Load<AudioClip>("die");
        placeTorch = Resources.Load<AudioClip>("placeTorch");
        destroyTorch = Resources.Load<AudioClip>("destroyTorch");
        shoot = Resources.Load<AudioClip>("shoot");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string name)
    {
        switch (name)
        {
            case "collapse":
                audioSource.PlayOneShot(collapse);
                break;

            case "die":
                audioSource.PlayOneShot(die);
                break;

            case "placeTorch":
                audioSource.PlayOneShot(placeTorch);
                break;

            case "destroyTorch":
                audioSource.PlayOneShot(destroyTorch);
                break;

            case "shoot":
                audioSource.PlayOneShot(shoot);
                break;
        }
    }
   
}
