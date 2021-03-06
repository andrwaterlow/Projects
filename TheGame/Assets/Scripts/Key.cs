using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour   
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            player.KeyUp();
            Destroy(gameObject);
        }
    }
}
