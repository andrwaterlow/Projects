namespace AsteroidsGame_HomeWork_
{
    public sealed class ShipDamageController : IDamage
    {
        ITakeDamage shipDamage;

        public ShipDamageController(ITakeDamage shipDamage)
        {
            this.shipDamage = shipDamage;
        }

        public void Damage(int damage)
        {
            shipDamage.HP -= damage;
        }  
    }
}
