using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManagement : MonoBehaviour
{
    public float currentHealth = 100f;

    public void ReceiveBullet(float bulletStrength)
    {
        currentHealth -= bulletStrength;
        if(currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }

}
