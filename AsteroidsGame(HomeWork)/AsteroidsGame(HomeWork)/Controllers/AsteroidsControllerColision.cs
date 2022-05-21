namespace AsteroidsGame_HomeWork_
{
    public sealed class AsteroidsControllerColision : IControlCollision
    {
        private ICollision ship;

        public AsteroidsControllerColision(ICollision ship)
        {
            this.ship = ship;
        }

        public bool CollisionObjectWithObject(ICollision asteroid)
        {
            return asteroid.Rect.IntersectsWith(ship.Rect);
        }         
    }
}
