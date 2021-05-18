using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    public float currentHealth = 80f;
    [SerializeField]
    public GameObject laser;
    [SerializeField]
    public float mobDistanceRun = 4.0f;    
    [SerializeField]
    public ParticleSystem dyingEffect;

    private readonly System.Random _rng = new System.Random();
    private bool _rotate;
    private Laser _laserScript;
    private GameObject _player;
    private NavMeshAgent _mob;
    private AudioSource _detectionSound;
    
    void Start()
    {
        _mob = GetComponent<NavMeshAgent>();
        _laserScript = laser.GetComponent<Laser>();
        _player = GameObject.Find("Player");
        _detectionSound = GetComponent<AudioSource>();

        _rotate = _rng.Next(0, 2) > 0;
    }
    
    void Update()
    {
        if (_laserScript.timeOff)
        {
            _detectionSound.enabled = false;
            _mob.isStopped = true;
            _laserScript.timeOff = false;
            _mob.ResetPath();
        }
        if (!_laserScript.Enemyfound)
        {
            transform.Rotate(new Vector3(0, _rotate ? -40 : 40, 0) * Time.deltaTime);  
        }
        else
        {
            _detectionSound.enabled = true;
            Vector3 dirToPlayer = transform.position - _player.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;
            _mob.SetDestination(newPos);         
        }
    }
    public void ReceiveBullet(float bulletStrength)
    {
        _laserScript.Enemyfound = true;
        currentHealth -= bulletStrength;
        if (currentHealth <= 0f)
        {
            //sound
            SoundManager.PlaySound("die");
            Instantiate(dyingEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
