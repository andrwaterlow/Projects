using UnityEngine;

namespace Assets.Scripts
{
    public sealed class Explodable : IExplodable 
    {
        public bool Exploded = false;

        public void Explosion(Vector3 position, float distance, float powerOfExplotion, GameObject gameObject, float damage)
        {
            var collisions = Physics.OverlapSphere(position, distance);

            foreach (var collider in collisions)
            {
                if (collider.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                {
                    ApplyDamage(collider, damage);

                    rigidbody.AddForce(powerOfExplotion, powerOfExplotion / 2, powerOfExplotion, ForceMode.Impulse);
                    rigidbody.AddTorque(Random.insideUnitSphere * powerOfExplotion * 4);
                }
            }
            Exploded = true;
        }

        private void ApplyDamage(Collider collider, float damage)
        {
            if (collider.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.MakeDamage(damage);
            }
        }
    }
}
