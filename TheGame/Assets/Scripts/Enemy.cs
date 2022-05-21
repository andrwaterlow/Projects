using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MortalObject, IDamagable
{
    private ParticleSystem _particleSystem;
    private AudioSource audioSource;

    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _bulletStartPosition;

    private float _rotation = 1f;
    [SerializeField] private int _maxBullet = 8;
    private int _currentBullet ;

    private Animator _animator;

    private Riffle _riffle;

    private NavMeshAgent navMeshAgent;
    int _currentWaypointIndex;

    private bool _activeAmmo = false;

    public void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        navMeshAgent.SetDestination(_wayPoints[0].position);
        
        _currentBullet = _maxBullet;

        _riffle = GetComponentInChildren<Riffle>();
        _riffle.SetStartPositionAndCenterScreen(_bulletStartPosition, transform);



    }

    void Update()
    {
        NormalWay();
    }
    
    private void SeePlayer()
    {
        if (_isAlive)
        {
            navMeshAgent.SetDestination(_player.position);
            SearchTarget();
            _animator.SetBool("Go", true);
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance * 2)
            {

                _animator.SetBool("Attack", true);
            }
            else
            {
                _animator.SetBool("Attack", false);
            }
        }
        
       
    }

    private void NormalWay()
    {
        if (_isAlive)
        {
            if (_wayPoints.Length > 1  )
            {
                _animator.SetBool("Go", true);

            }
            else
            {
                _animator.SetBool("Go", false);
            }

                if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance && _activeAmmo == false)
                {

                    _currentWaypointIndex = (_currentWaypointIndex + 1);
                    if (_currentWaypointIndex == _wayPoints.Length)
                    {
                        _currentWaypointIndex = 0;
                    }

                    navMeshAgent.SetDestination(_wayPoints[_currentWaypointIndex].position);
                }
            
        }
       
    }

    private void DeathOrLive()
    {
        if (!_isAlive)
        {
           StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        navMeshAgent.speed = 0;
        _animator.SetBool("Death", true);
        Destroy(navMeshAgent);
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _isAlive)
        {
            bool check = other.GetComponent<Player>().IsAlive;
            if (check)
            {
                if (_currentBullet > 0)
                {
                    navMeshAgent.SetDestination(gameObject.transform.position);
                    _activeAmmo = true;
                    _animator.SetBool("Attack2", true);
                    SearchTarget();
                }
                else
                {
                    _animator.SetBool("Attack2", false);
                    _activeAmmo = false;
                    SeePlayer();
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && _isAlive)
        {
            bool check = other.GetComponent<Player>().IsAlive;
            if (check)
            {
                if (_riffle.CurrentAmmoInGun > 0)
                {
                    navMeshAgent.SetDestination(gameObject.transform.position);
                    _activeAmmo = true;
                    _animator.SetBool("Attack2", true);
                    SearchTarget();
                }
                else
                {
                    _animator.SetBool("Attack2", false);
                    _activeAmmo = false;
                    SeePlayer();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other )
    {
        if (other.CompareTag("Player") && _isAlive)
        {
            bool check = other.GetComponent<Player>().IsAlive;
            if (check)
            { 
            _animator.SetBool("Attack2", false);
            _activeAmmo = false;
            }
        }
    }

    private void Shot()
    {
        int dam = 2 * Random.Range(1,5);
        _riffle.Shot();
    }

    private void SearchTarget()
    {
        Vector3 relative = _player.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, relative, _rotation * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

     private void Ammo()
    {
        _currentBullet -= 1;
    }

    private void PLaySound()
    {
        audioSource.Play();
    }

    public void MakeDamage(float damage)
    {
        _damage.TakeDamage(damage);
        _particleSystem.Play();
        _isAlive = _damage.CheckLiveStatus();
        DeathOrLive();
    }
}
