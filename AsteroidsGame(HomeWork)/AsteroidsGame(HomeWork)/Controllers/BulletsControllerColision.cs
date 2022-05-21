namespace AsteroidsGame_HomeWork_
{
    public sealed class BulletsControllerColision : IControlCollision
    {
        private AsteroidsList asteroids;
        private ICollision asteroid;

        public BulletsControllerColision(AsteroidsList asteroids)
        {
            this.asteroids = asteroids;
        }

        public bool CollisionObjectWithObject(ICollision bullet)
        {
            for (int i = 0; i < asteroids.asteroids.Count; i++)
            {
                asteroid = asteroids.asteroids[i];
                
                    if (bullet.Rect.IntersectsWith(asteroid.Rect))
                    {
                        asteroids.asteroids[i].CollisionWithBool();
                        
                        return true;
                    }
            }

            return false;
        }
    }
}
