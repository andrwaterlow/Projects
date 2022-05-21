using UnityEngine;

public class END : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<IDamagable>().MakeDamage(10000);
        }
    }
}
