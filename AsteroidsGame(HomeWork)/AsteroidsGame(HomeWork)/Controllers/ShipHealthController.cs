namespace AsteroidsGame_HomeWork_
{
    public sealed class ShipHealthController : IHealth
    {
        private ITakeHP shipHP;

        public ShipHealthController(ITakeHP shipHP)
        {
            this.shipHP = shipHP;
        }

        public void Health(int HealthUP)
        {
            shipHP.HP += HealthUP;
        }
    }
}
