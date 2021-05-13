using UnityEngine;

public class ShootingManagement : MonoBehaviour
{
    public Camera cam;
    public float bulletStrength = 20f;
    public ParticleSystem flash;
    public GameObject bleedingEffect;
    public GameObject smokeEffect;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !GameSetup.isFinished)
        {
            flash.Play();
            RaycastHit hit;
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                EnemyAI target = hit.transform.root.GetComponent<EnemyAI>();
                //anim
                animator.SetTrigger("isShooting");
                if (target != null)
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
                if(GameSetup.bulletAmount > 0)GameSetup.bulletAmount--;
                if(GameSetup.bulletAmount == 0)
                {
                    Destroy(gameObject.transform.parent.gameObject);
                }
                
            }
        }
    }
}
