using UnityEngine;

public class END : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamagable>(out var damagable))
        {
            damagable.MakeDamage(10000);
        }
    }
}
