using AsteroidsGame_HomeWork_.Properties;
using System;
using System.Drawing;
using AsteroidsGame_HomeWork_.Scenes;
using AsteroidsGame_HomeWork_.Interfaces;

namespace AsteroidsGame_HomeWork_
{
    public class Ship : BaseObject, ITakeDamage, ITakeHP
    {
        public int HP { get;  set; } = 100; 

        private BulletsList bulletsList;
        internal PointsController pointsController;

        private IDamage takeDamage;
        private IHealth takeHealth;
        private ISound sound;

        public event Action MessageDie;
        
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            takeDamage = new ShipDamageController(this);
            takeHealth = new ShipHealthController(this);
        }

        public void LoadDataObject(BulletsList bulletsList, ISound sound, PointsController pointsController)
        {
            this.bulletsList = bulletsList;
            this.sound = sound;
            this.pointsController = pointsController;
        }

        public override void Draw() 
        {
            Resources.ship.RotateFlip(RotateFlipType.Rotate270FlipNone);
            Game.Buffer.Graphics.DrawImage(Resources.ship, CurrentPosition.X, CurrentPosition.Y, SizeOfObject.Width, SizeOfObject.Height); 
        }

        public override void Update()
        {
            Die();
        }

        public void TakeDamage(int shipDamage)
        {
            takeDamage.Damage(shipDamage);
        }

        public void Left()
        {
            if (CurrentPosition.X > 0) CurrentPosition.X = CurrentPosition.X - Dir.X;
        }

        public void Right()
        {
            if (CurrentPosition.X < Game.Width) CurrentPosition.X = CurrentPosition.X + Dir.X;
        }

        public void Die()
        {
            if (HP <= 0)
            {
                MessageDie.Invoke();
                sound.PlaySound(sound.explode);
            }
        }

        public void  Shot() 
        {
            bulletsList.CreateBullet(this);
            sound.PlaySound(sound.shot);
        }

        public void TakeHP(int health)
        {
            takeHealth.Health(health);
        }
    }
}
