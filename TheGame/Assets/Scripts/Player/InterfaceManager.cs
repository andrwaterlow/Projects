namespace Assets.Scripts
{
    public sealed class InterfaceManager : IInterfaceManager
    {
        private Health _health;
        private Armour _armour;
        private GunsList _gunsList;

        public InterfaceManager(Health health, Armour armour, GunsList gunsList)
        {
            _health = health;
            _armour = armour;
            _gunsList = gunsList;
        }

        public (int curbull, int gunbull) Ammo()
        {
            int curbull = _gunsList.CurrentGun.CurrentAmmo;
            int gunbull = _gunsList.CurrentGun.CurrentAmmoInGun;
            return (curbull, gunbull);
        }

        public float HP()
        {
            return _health._currentHealth;
        }

        public float Armour()
        {
            return _armour._currentArmour;
        }
    }
}
