using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float _currentTime = 0;
    private float _attackTime = 0.8f;
    [SerializeField] private float _power = 0f;
    [SerializeField]private int _damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamagable>(out var damagable))
        {
            if (_currentTime >= _attackTime && !other.TryGetComponent<Enemy>(out var enemy))
            {
                damagable.MakeDamage(_damage * Random.Range(1, 3));
                var explode = other.gameObject.GetComponent<Rigidbody>();
                explode.AddForce(_power, _power/ 2, _power, ForceMode.Impulse);
                
                _currentTime = 0;
            }
           
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<IDamagable>(out var damagable))
        {
            if (_currentTime >= _attackTime && !other.TryGetComponent<Enemy>(out var enemy))
            {
                damagable.MakeDamage(_damage * Random.Range(1, 3));
                var explode = other.gameObject.GetComponent<Rigidbody>();
                explode.AddForce(_power, _power / 2, _power, ForceMode.Impulse);

                _currentTime = 0;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
