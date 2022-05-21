using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BOSS : MortalObject, IDamagable
{
    [SerializeField] Transform _player ;
 

    private float _rotation = 2;
    private float _currentBazooka = 20;
    private float _currentGrenade = 0;
    private float _currentGun = 0;

    private float _reloadBazooka = 10;
    private float _reloadGrenade = 8;
    private float _reloadGun = 4;

    public GameObject GrenadePref;
    public Transform GrenadeStartPosition;

    public GameObject BulletPref;
    public Transform MissleStartPosition;

    private int _weapon;

    [SerializeField] private float _longOfShot = 20000f;
    [SerializeField] private float _longOfShotForGrenade = 1000f;

    public Transform BulletStartPosition;

    private bool _activeAmmo = false;

    private float _currentHP;
   [SerializeField] private float _maxHP = 5000;

    NavMeshAgent navMeshAgent;

    private int _currentWaypointIndex;

    [SerializeField] Transform[] _wayPoints;

    private Animator _animator;


    int gun = 0;





    private void Awake()
    {
        _currentHP = _maxHP;
        _animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        _armour = new Armour(500f, 500f);
        _health = new Health(2500f, 2500f);
        _damage = new Damage(_health, _armour);
    }

    private void NormalWay()
    {
        if (_isAlive)
        {
            if (_wayPoints.Length > 1)
            {
                _animator.SetBool("GoBoss", true);

            }
            else
            {
                _animator.SetBool("GoBoss", false);
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

    private void Start()
    {
        navMeshAgent.SetDestination(_wayPoints[0].position);
    }

    private void Update()
    {
      
        _currentBazooka += Time.deltaTime;
        _currentGrenade += Time.deltaTime;
        _currentGun += Time.deltaTime;
        NormalWay();
        Debug.Log(_health._currentHealth);
    }

    public void CreateBullet()
    {
        if (_weapon == 0 )
        {
            int dam = 15;
            RaycastHit hit;
            var rayCast = Physics.Raycast(BulletStartPosition.position, transform.forward, out hit, 30f);
            if (rayCast)
            {
                if (hit.collider.gameObject.CompareTag("Player") || hit.collider.gameObject.CompareTag("Barrel")
                    || hit.collider.gameObject.CompareTag("Turret") || hit.collider.gameObject.CompareTag("AmmoBoxes"))
                {
                    hit.collider.gameObject.GetComponent<ITakeDamage>().TakeDamage(dam);
                }
            }
            _currentGun -= 4;

        }
        if (_weapon == 1)
        {

            var bullet = Instantiate(BulletPref, BulletStartPosition.position, transform.rotation).GetComponent<Rigidbody>();

            bullet.AddForce(GetComponent<BOSS>().transform.forward * _longOfShot);
            
            _currentBazooka = 0;

        }
        if (_weapon == 2 )
        {
            var grenade = Instantiate(GrenadePref, GrenadeStartPosition.position, transform.rotation).GetComponent<Rigidbody>();
            grenade.AddForce(GetComponent<BOSS>().gameObject.transform.up * _longOfShotForGrenade / 2);
            grenade.AddForce(GetComponent<BOSS>().gameObject.transform.forward * _longOfShotForGrenade*3);
            grenade.AddTorque(Random.insideUnitSphere * _longOfShotForGrenade);
            
            _currentGrenade = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _isAlive)
        {
            bool check = other.GetComponent<Player>().IsAlive;
            if (check)    
            {
                _activeAmmo = true;
                 if  (_currentGun > _reloadGun && gun <= 3)
                {
                    _weapon = 0;
                    _animator.SetBool("AttackBoss3", false);
                    _animator.SetBool("AttackBoss2", false);
                    navMeshAgent.SetDestination(gameObject.transform.position);
                    _animator.SetBool("AttackBoss", true);
                    SearchTarget();
                    gun++;
                }

               else if (_currentBazooka > _reloadBazooka && gun <=4)
                {
                    _weapon = 1;
                    _animator.SetBool("AttackBoss", false);
                    _animator.SetBool("AttackBoss3", false);
                    navMeshAgent.SetDestination(gameObject.transform.position);
                   _animator.SetBool("AttackBoss2", true);
                    SearchTarget();
                    gun = 0;
                }



                else if (_currentGrenade > _reloadGrenade && gun <= 1)
                {

                    _weapon = 2;
                    _animator.SetBool("AttackBoss2", false);
                    _animator.SetBool("AttackBoss", false);
                    _animator.SetBool("AttackBoss3", false);
                    navMeshAgent.SetDestination(gameObject.transform.position);
                    SearchTarget();
                    CreateBullet();
                    gun++;

                }

                else
                {
                    _animator.SetBool("AttackBoss2", false);
                    _animator.SetBool("AttackBoss", false);
                    _animator.SetBool("AttackBoss3", false);
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
                _activeAmmo = true;
                if (_currentGun > _reloadGun && gun <= 3)
                {
                    _weapon = 0;
                    _animator.SetBool("AttackBoss3", false);
                    _animator.SetBool("AttackBoss2", false);
                    navMeshAgent.SetDestination(gameObject.transform.position);
                    _animator.SetBool("AttackBoss", true);
                    SearchTarget();
                    gun++;
                }

                else if (_currentBazooka > _reloadBazooka && gun <= 4)
                {
                    _weapon = 1;
                    _animator.SetBool("AttackBoss", false);
                    _animator.SetBool("AttackBoss3", false);
                    navMeshAgent.SetDestination(gameObject.transform.position);
                    _animator.SetBool("AttackBoss2", true);
                    SearchTarget();
                    gun = 0;
                }

                else if (_currentGrenade > _reloadGrenade && gun <= 1)
                {
                    _weapon = 2;
                    _animator.SetBool("AttackBoss2", false);
                    _animator.SetBool("AttackBoss", false);
                    _animator.SetBool("AttackBoss3", false);
                    navMeshAgent.SetDestination(gameObject.transform.position);
                    SearchTarget();
                    CreateBullet();
                    gun++;
                }

                else
                {
                    _animator.SetBool("AttackBoss2", false);
                    _animator.SetBool("AttackBoss", false);
                    _animator.SetBool("AttackBoss3", false);
                    SeePlayer();
                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _isAlive)
        {
            _animator.SetBool("AttackBoss3", false);
            _animator.SetBool("AttackBoss", false);
            _animator.SetBool("AttackBoss2", false);
            _activeAmmo = false; 
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
        _animator.SetBool("DeathBoss1", true);
        Destroy(navMeshAgent);
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        _currentHP -= damage;
        DeathOrLive();
    }

    private void SearchTarget()
    {
        Vector3 relative = _player.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, relative, _rotation * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void SeePlayer()
    {
        if (_isAlive)
        {
            navMeshAgent.SetDestination(_player.position);
            SearchTarget();
            _animator.SetBool("GoBoss", true);
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance * 2)
            {

                _animator.SetBool("AttackBoss3", true);
            }
            else
            {
                _animator.SetBool("AttackBoss3", false);
            }
        }
    }

    public void MakeDamage(float damage)
    {
        _damage.TakeDamage(damage);
        _isAlive = _damage.CheckLiveStatus();
        DeathOrLive();
    }
}
