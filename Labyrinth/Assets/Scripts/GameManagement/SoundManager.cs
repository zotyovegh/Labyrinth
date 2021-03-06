using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip collapse, die, placeTorch, destroyTorch, shoot;
    static AudioSource _audioSource;

    void Start()
    {
        collapse = Resources.Load<AudioClip>("collapse");
        die = Resources.Load<AudioClip>("die");
        placeTorch = Resources.Load<AudioClip>("placeTorch");
        destroyTorch = Resources.Load<AudioClip>("destroyTorch");
        shoot = Resources.Load<AudioClip>("shoot");

        _audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string name)
    {
        switch (name)
        {
            case "collapse":                
                _audioSource.PlayOneShot(collapse);
                break;

            case "die":
                _audioSource.PlayOneShot(die);
                break;

            case "placeTorch":
                _audioSource.PlayOneShot(placeTorch);
                break;

            case "destroyTorch":
                _audioSource.PlayOneShot(destroyTorch);
                break;

            case "shoot":
                _audioSource.PlayOneShot(shoot);
                break;
        }
    }
}
