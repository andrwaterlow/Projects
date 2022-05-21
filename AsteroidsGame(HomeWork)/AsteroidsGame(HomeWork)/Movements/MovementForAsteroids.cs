using AsteroidsGame_HomeWork_.Scenes;

namespace AsteroidsGame_HomeWork_
{
    public sealed class MovementForAsteroids : IMovement
    {
        public void Move(BaseObject asteroid)
        {
            asteroid.CurrentPosition.X = asteroid.CurrentPosition.X + asteroid.Dir.X;
            asteroid.CurrentPosition.Y = asteroid.CurrentPosition.Y + asteroid.Dir.Y;
            CheckHeightScreen(asteroid);
            CheckWightScreen(asteroid);
        }

        private void CheckHeightScreen(BaseObject asteroid)
        {
            if (asteroid.CurrentPosition.Y < 0) asteroid.Dir.Y = -asteroid.Dir.Y;
            if (asteroid.CurrentPosition.Y >= Game.Height) asteroid.Dir.Y = -asteroid.Dir.Y;
        }

        private void CheckWightScreen(BaseObject asteroid)
        {
            if (asteroid.CurrentPosition.X < 0) asteroid.Dir.X = -asteroid.Dir.X;
            if (asteroid.CurrentPosition.X >= Game.Width) asteroid.Dir.X = -asteroid.Dir.X;
        }
    }
}
