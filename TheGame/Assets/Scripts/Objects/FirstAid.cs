using UnityEngine;

public class FirstAid : MonoBehaviour
{
    [SerializeField] private int _getHp = 25;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            player.ItemManager.HealthUp(_getHp);
            Destroy(gameObject);
        }
    }
}
