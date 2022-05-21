namespace AsteroidsGame_HomeWork_
{
    public sealed class Factories : IFactories
    {
        private IFactoryAsteroids asteroids;
        private IFactoryComet comet;
        private IFactoryHealth health;
        private IFactoryShip ship;
        private IFactoryStars stars;
        private IFactoryBullets bullets;

        public Factories ()
        {
            FactoryBullets();
            FactoryAsteroids();
            FactoryShip();
            FactoryComet();
            FactoryStars();
            FactoryHealth();
        }

        public IFactoryBullets FactoryBullets()
        {
            if (bullets == null)
            {
                return bullets = new FactoryBullets();
            }

            return bullets;
        }

        public IFactoryAsteroids FactoryAsteroids()
        {
            if (asteroids == null)
            {
                return asteroids = new FactoryAsteroids();
            }

            return asteroids;
        }

        public IFactoryShip FactoryShip()
        {
            if (ship == null)
            {
                return ship = new FactoryShip();
            }

            return ship;
        }

        public IFactoryComet FactoryComet()
        {
            if (comet == null)
            {
                return comet = new FactoryComet();
            }

            return comet;
        }

        public IFactoryHealth FactoryHealth()
        {
            if (health == null)
            {
                return health = new FactoryHealth();
            }

            return health;
        }

        public IFactoryStars FactoryStars()
        {
            if (stars == null)
            {
                return stars = new FactoryStars();
            }

            return stars;
        }
    }
}
