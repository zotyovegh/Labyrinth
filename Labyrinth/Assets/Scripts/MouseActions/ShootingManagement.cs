using UnityEngine;

public class ShootingManagement : MonoBehaviour
{
    [SerializeField]
    public Camera cam;
    [SerializeField]
    public float bulletStrength = 20f;
    [SerializeField]
    public ParticleSystem flash;
    [SerializeField]
    public GameObject bleedingEffect;
    [SerializeField]
    public GameObject smokeEffect;
    [SerializeField]
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
                //sound
                SoundManager.PlaySound("shoot");
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
