using AsteroidsGame_HomeWork_.Properties;
using System.Drawing;
using AsteroidsGame_HomeWork_.Scenes;
using System;

namespace AsteroidsGame_HomeWork_
{
    public sealed class Asteroid : BaseObject
    {
        private int Id;

        private IMovement movement;

        private int minDamage = 10;
        private int maxDamage = 19;

        public bool Collision { get; private set; } = false;

        public Asteroid(Point pos, Point dir, Size size, int id) : base (pos, dir, size)
        {
            Id = id;
            movement = new MovementForAsteroids();
        }

        public override void Draw() 
        {
            switch (Id)
            {
                case 1: 
                    Game.Buffer.Graphics.DrawImage(Resources.meteorBrown_big1, CurrentPosition.X, CurrentPosition.Y, SizeOfObject.Width, SizeOfObject.Height);
                    break;
                case 2:
                    Game.Buffer.Graphics.DrawImage(Resources.meteorBrown_big2, CurrentPosition.X, CurrentPosition.Y, SizeOfObject.Width, SizeOfObject.Height);
                    break;
                case 3:
                    Game.Buffer.Graphics.DrawImage(Resources.meteorBrown_big3, CurrentPosition.X, CurrentPosition.Y, SizeOfObject.Width, SizeOfObject.Height);
                    break;
                case 4:
                    Game.Buffer.Graphics.DrawImage(Resources.meteorBrown_big4, CurrentPosition.X, CurrentPosition.Y, SizeOfObject.Width, SizeOfObject.Height);
                    break;
            }  
        }
   
        public override void Update() 
        {
            movement.Move(this);
        }

        public int RandomDamage()
        {
            Random damage = new Random();
            return damage.Next(minDamage, maxDamage);
        }

        public void CollisionWithBool()
        {
            Collision = true;
        }
    }
}
