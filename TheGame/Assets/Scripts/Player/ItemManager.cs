namespace Assets.Scripts
{
    public sealed class ItemManager : IItemManager
    {
        private Health _health;
        private Armour _armour;
        private GunsList _gunsList;
        private PropertyOfRampage _propertyOfRampage;

        public ItemManager(Health health, Armour armour, GunsList gunsList, PropertyOfRampage propertyOfRampage)
        {
            _health = health;
            _armour = armour;
            _gunsList = gunsList;
            _propertyOfRampage = propertyOfRampage;
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

        public void UseRampage(int rampageCurrentAmmoInGun, float rampageDelay, float rampageSpeed)
        {
            _propertyOfRampage.ActiveOrDeactiveRampage(rampageCurrentAmmoInGun, rampageDelay, rampageSpeed);
        }
    }
}
