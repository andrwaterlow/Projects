namespace AsteroidsGame_HomeWork_
{
    public sealed class MovementForBullet : IMovement
    {
        public void Move(BaseObject bullet)
        {
            bullet.CurrentPosition.Y = bullet.CurrentPosition.Y - bullet.Dir.Y;
        }
    }
}
