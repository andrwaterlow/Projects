using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int _getAmmo = 30;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            player.ItemManager.AmmoForRiffleUp(_getAmmo);
            Destroy(gameObject);
        }
    }
}
