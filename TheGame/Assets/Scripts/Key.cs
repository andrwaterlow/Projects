using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour   
{
    [SerializeField] private GameObject _door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().KeyUp();
            Destroy(gameObject);
        }
    }
}
