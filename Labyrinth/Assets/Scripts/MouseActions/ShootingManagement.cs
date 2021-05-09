﻿using UnityEngine;

public class ShootingManagement : MonoBehaviour
{
    public Camera cam;
    public float bulletStrength = 20f;
    public ParticleSystem flash;
    public GameObject bleedingEffect;
    public GameObject smokeEffect;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            flash.Play();
            RaycastHit hit;
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                EnemyAI target = hit.transform.root.GetComponent<EnemyAI>();
                if(target != null)
                {
                    target.ReceiveBullet(bulletStrength);
                    GameObject obj = Instantiate(bleedingEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(obj, 2f);
                }
                else
                {
                    GameObject obj = Instantiate(smokeEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(obj, 2f);
                }
                
            }
        }
    }
}