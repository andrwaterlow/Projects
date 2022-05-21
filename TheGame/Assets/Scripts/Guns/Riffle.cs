using UnityEngine;

namespace Assets.Scripts
{
    public sealed class Riffle : Gun
    {
        private GameObject _rifflePrefab;
        private LineRenderer _liser;

        private void Awake()
        {
            IsActive = true;
            Delay = false;
            TimeDelay = 0.1f;
            Damage = 15;
            TimeReloading = 3;
            MaxAmmo = 250;
            MaxAmmoInGun = 30;
            CurrentAmmoInGun = Mathf.Clamp(MaxAmmoInGun, 0, MaxAmmoInGun);
            CurrentAmmo = Mathf.Clamp(MaxAmmo, 0, MaxAmmo);
            _rifflePrefab = Resources.Load<GameObject>("Riffle");
            _liser = GetComponentInParent<LineRenderer>();
        }

        protected override void SpecificGunShot()
        {
            StartPositionForLiser();

            RaycastHit hit;
            var rayCast = Physics.Raycast(StartPosition.position,
                CenterScreen.forward, out hit, 30f);

            TreatmentHit(rayCast, hit);
        }

        private void StartPositionForLiser()
        {
            /*_liser.enabled = true;*/
            _liser.SetPosition(0, StartPosition.position);
        }

        private void TreatmentHit(bool rayCast, RaycastHit hit)
        {
            if (rayCast)
            {
                EndPositionForLiser(hit);
                Debug.Log(hit);
                if (hit.collider.TryGetComponent<IDamagable>(out IDamagable damagable))
                {
                    Debug.Log(damagable);
                    damagable.MakeDamage(Damage);
                }
            }
        }

        private void EndPositionForLiser(RaycastHit hit)
        {
            _liser.SetPosition(1, hit.point);
            /*_liser.enabled = false;*/
        }
    }
}
