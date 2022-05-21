using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Door _door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out var player))
        {
            _door.UnlockDoor();
            Debug.Log("sew");
        }
    }
}
