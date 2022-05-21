using UnityEngine;

public class Barrels : MonoBehaviour
{
    [SerializeField] private float _speedRotation = 5;
    [SerializeField] private Transform _playerPosition;
    
    [SerializeField] private float _distance = 8;
    
    public Transform BulletStartPosition;
    private AudioSource _audioSource;

    private float _curentTime = 0;
    private float _timeShot = 0.3f ;

    private void Update()
    {
        _curentTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool playerlive = other.GetComponent<Player>().IsAlive;
            if (playerlive)
            { 
            Fire();
         }
        }

    }

    private void Awake()
    {
        _audioSource = GetComponent < AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool playerlive = other.GetComponent<Player>().IsAlive;
            if (playerlive)
            {
             
                Fire();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.Rotate(Vector3.zero * _speedRotation);
    }


    private void PLaySound()
    {
        _audioSource.Play();
    }

    private void Fire()
    {
        transform.Rotate(Vector3.forward * _speedRotation);
        CreateBullet();
    }

    private void CreateBullet()
    {
        if (_curentTime >= _timeShot)
        {
            int dam = 5;
            RaycastHit hit;
            var rayCast = Physics.Raycast(BulletStartPosition.position, transform.forward, out hit, Mathf.Infinity);
            if (rayCast)
            {
                if (hit.collider.TryGetComponent<IDamagable>(out var damagable))
                {
                    damagable.MakeDamage(dam);
                }
            }
            _curentTime = 0;
        }
    }
}
