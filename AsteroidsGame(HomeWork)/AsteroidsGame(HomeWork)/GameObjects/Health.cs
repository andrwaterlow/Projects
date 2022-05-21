using AsteroidsGame_HomeWork_.Properties;
using System.Drawing;
using AsteroidsGame_HomeWork_.Scenes;

namespace AsteroidsGame_HomeWork_
{
    public sealed class Health : BaseObject
    {
        public int HP { get; private set; }

        public bool Collision { get; private set; }

        public Health(Point pos, Point dir, Size size, int hp) : base(pos, dir, size)
        {
            HP = hp;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Resources.Health, CurrentPosition.X, CurrentPosition.Y, SizeOfObject.Width, SizeOfObject.Height);
        }

        public override void Update()
        {
            // на будущее
        }

        public void CollisionWithShip()
        {
            Collision = true;
        }
    }
}
