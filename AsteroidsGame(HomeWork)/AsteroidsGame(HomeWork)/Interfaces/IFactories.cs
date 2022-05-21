namespace AsteroidsGame_HomeWork_
{
    public interface IFactories
    {
        IFactoryAsteroids FactoryAsteroids();
        IFactoryComet FactoryComet();
        IFactoryHealth FactoryHealth();
        IFactoryShip FactoryShip();
        IFactoryStars FactoryStars();
        IFactoryBullets FactoryBullets();
    }
}
