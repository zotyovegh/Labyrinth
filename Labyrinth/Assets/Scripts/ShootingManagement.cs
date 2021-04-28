using UnityEngine;

public class ShootingManagement : MonoBehaviour
{
    public Camera cam;
    public float bulletStrength = 20f;
    public ParticleSystem flash;
    public GameObject bleedingEffect;
    public GameObject smokeEffect;

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) // && gun is chosen
        {
            flash.Play();
            RaycastHit hit;
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                Debug.Log(hit.transform.root.name);

                LifeManagement target = hit.transform.root.GetComponent<LifeManagement>();
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
