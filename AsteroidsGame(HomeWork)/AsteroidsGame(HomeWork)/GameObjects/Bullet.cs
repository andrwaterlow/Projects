using AsteroidsGame_HomeWork_.Properties;
using System.Drawing;
using AsteroidsGame_HomeWork_.Scenes;

namespace AsteroidsGame_HomeWork_
{
    public sealed class Bullet : BaseObject
    {
        private IMovement movement;

        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            movement = new MovementForBullet();
        }

        public override void Draw()
        {
            Bitmap box = new Bitmap(Resources.bullet1);
            box.RotateFlip(RotateFlipType.Rotate270FlipNone);
            Game.Buffer.Graphics.DrawImage(box, CurrentPosition.X, CurrentPosition.Y, SizeOfObject.Width, SizeOfObject.Height);
        }

        public override void Update()
        {
            movement.Move(this);
        }
    }
}
