using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turet : MortalObject, IDamagable
{
    [SerializeField] private Transform _playerPosition;
   
    [SerializeField] private float _speedRotationActive = 1;

    [SerializeField] private int _maxHP = 150;
    private int _currentHP;

    private AudioSource _audioSource;

    


    private Animator _animator;

    private void Awake()
    {
        _currentHP = _maxHP;
        _animator = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _isAlive)
        {
            bool playerlive = other.GetComponent<Player>().IsAlive;
            if(playerlive)
            {
                _animator.enabled = false;


                TurretAttack();
            }
            
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && _isAlive)
        {
            bool playerlive = other.GetComponent<Player>().IsAlive;
            if (playerlive)
            {
                


                TurretAttack();
            }

            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player" ) && _isAlive)
        { 

        
        _animator.enabled = true;

            bool playerlive = other.GetComponent<Player>().IsAlive;
            if (playerlive)
            {



                _animator.enabled = true;
            }

        }

    }

    private void TurretAttack()
    {
        if (_isAlive)
        { 
        var head = gameObject.transform.GetChild(0).transform.GetChild(0).transform;
        Vector3 relative = _playerPosition.position - head.position;
        Vector3 newDir = Vector3.RotateTowards(head.forward, relative, _speedRotationActive * Time.deltaTime, 0f);
        head.rotation = Quaternion.LookRotation(newDir);
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
        
        _animator.SetTrigger("DeathTurret");
        /*_animator.Play("DeathTurret");*/
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    

    private void PLaySound()
    {
        _audioSource.Play();
    }

    

    public void MakeDamage(float damage)
    {
        _damage.TakeDamage(damage);
        _isAlive = _damage.CheckLiveStatus();
        DeathOrLive();
    }
}

