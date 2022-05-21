using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 3 ;
    private Transform _enemyPosition;
    [SerializeField] private int _damage = 100;
    
    

    public int Damage ()
    {
        return _damage; 
    } 

    

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(_damage);
        }
       
        Destroy(gameObject);
    }
}
