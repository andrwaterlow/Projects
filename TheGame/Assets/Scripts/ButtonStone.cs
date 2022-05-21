using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStone : MonoBehaviour
{
    [SerializeField] private GameObject _bossDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Stone>(out var stone))
        {
            _bossDoor.GetComponent<Door>().UnlockDoor();
        }
    }
     
}
