using AsteroidsGame_HomeWork_.Properties;
using System.Drawing;
using AsteroidsGame_HomeWork_.Scenes;

namespace AsteroidsGame_HomeWork_
{
    class Star : BaseObject
    {
        private int Id;

        private IMovement movement;

        public Star(Point pos, Point dir, Size size, int id) : base(pos, dir, size)
        {
            Id = id;
            movement = new MovementForAsteroids();
        }

         public override void Draw()
        {
            switch (Id)
            {
                case 1:
                    Game.Buffer.Graphics.DrawImage(Resources.star1, CurrentPosition.X, CurrentPosition.Y, SizeOfObject.Width, SizeOfObject.Height);
                    break;
                case 2:
                    Game.Buffer.Graphics.DrawImage(Resources.star2, CurrentPosition.X, CurrentPosition.Y, SizeOfObject.Width, SizeOfObject.Height);
                    break;
                case 3:
                    Game.Buffer.Graphics.DrawImage(Resources.star3, CurrentPosition.X, CurrentPosition.Y, SizeOfObject.Width, SizeOfObject.Height);
                    break;
            }
        }

         public override void Update()
        {
            movement.Move(this);
        }
    }
}
