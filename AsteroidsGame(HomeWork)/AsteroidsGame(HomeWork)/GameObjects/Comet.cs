using AsteroidsGame_HomeWork_.Properties;
using System.Drawing;
using AsteroidsGame_HomeWork_.Scenes;

namespace AsteroidsGame_HomeWork_
{
    public sealed class Comet : BaseObject
    {
        private IMovement movement;

        public Comet(Point pos, Point dir, Size size, IMovement movement) : base(pos, dir, size)
        {
            this.movement = movement;
        }

        public override void Draw()
        {       
            Game.Buffer.Graphics.DrawImage(Resources.comet3, CurrentPosition.X, CurrentPosition.Y, SizeOfObject.Width, SizeOfObject.Height);
        }

        public override void Update()
        {
            movement.Move(this);
        }
    }
}
