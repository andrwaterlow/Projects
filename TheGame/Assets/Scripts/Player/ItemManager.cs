namespace Assets.Scripts
{
    public sealed class ItemManager : IItemManager
    {
        private Health _health;
        private Armour _armour;
        private GunsList _gunsList;

        public ItemManager(Health health, Armour armour, GunsList gunsList)
        {
            _health = health;
            _armour = armour;
            _gunsList = gunsList;
        }

        public void HealthUp(float plusHP)
        {
            _health._currentHealth += plusHP;
        }

        public void ArmourUp(float plusArmour)
        {
            _armour._currentArmour += plusArmour;
        }

        public void AmmoForRiffleUp(int plusAmmo)
        {
            _gunsList.Riffle.AmmoUp(plusAmmo);
        }

        public void AmmoForBazookaUp(int plusAmmo)
        {
            _gunsList.Bazooka.AmmoUp(plusAmmo);
        }

        public void AmmoForGrenadeUp(int plusAmmo)
        {
            _gunsList.Grenade.AmmoUp(plusAmmo);
        }

        public void AmmoForMineUp(int plusAmmo)
        {
            _gunsList.Mine.AmmoUp(plusAmmo);
        }
    }
}
