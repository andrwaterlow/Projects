using AsteroidsGame_HomeWork_.Properties;
using AsteroidsGame_HomeWork_.Scenes;
using System;

namespace AsteroidsGame_HomeWork_
{
    public sealed class MovementForComet : IMovement
    {
        public void Move(BaseObject comet)
        {
            comet.CurrentPosition.X = comet.CurrentPosition.X - comet.Dir.X;
            comet.CurrentPosition.Y = comet.CurrentPosition.Y + comet.Dir.Y;
            CreateNewPosition(comet);
        }

        private void CreateNewPosition(BaseObject comet)
        {
            Random RandomPosX = new Random();
            Random RandomPosY = new Random();

            if (comet.CurrentPosition.X < 0 - Resources.comet3.Size.Width) comet.CurrentPosition.X = RandomPosX.Next(810, 900);

            if (comet.CurrentPosition.Y >= Game.Height + Resources.comet3.Size.Height) comet.CurrentPosition.Y = RandomPosY.Next(-30, -10);
        }
    }
}
