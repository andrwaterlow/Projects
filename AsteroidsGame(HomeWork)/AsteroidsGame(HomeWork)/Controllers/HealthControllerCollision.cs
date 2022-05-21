namespace AsteroidsGame_HomeWork_
{
    public sealed class HealthControllerCollision : IControlCollision
    {
        private ICollision ship;

        public HealthControllerCollision(ICollision ship)
        {
            this.ship = ship;
        }

        public bool CollisionObjectWithObject(ICollision health)
        {
            return health.Rect.IntersectsWith(ship.Rect);
        }
    }
}
