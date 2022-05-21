using System.Collections.Generic;

namespace AsteroidsGame_HomeWork_
{
    public sealed class BulletsList
    {
        public List<BaseObject> bullets;

        private IControlAction bulletController;
        private IControlCollision controllerColision;
        private IFactoryBullets factoryBullets;

        public BulletsList(AsteroidsList asteroidsList, IFactoryBullets factoryBullets)
        {
            bullets = new List<BaseObject>();
            bulletController = new BulletController(bullets);
            controllerColision = new BulletsControllerColision(asteroidsList);
            this.factoryBullets = factoryBullets;
        }

        public void Update()
        {
            CheckBulletsAndUpdate();
        }

        private void CheckBulletsAndUpdate()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();

                if (CheckCollisionWithAsteroids(bullets[i]))
                {
                    bullets.RemoveAt(i);
                }
                else
                {
                    CheckCurrentPosition(bullets[i]);
                }
            }
        }

        private bool CheckCollisionWithAsteroids(BaseObject bullet)
        {
            return controllerColision.CollisionObjectWithObject(bullet);
        }

        private void CheckCurrentPosition(BaseObject bullet)
        {
            bulletController.Death(bullet);         
        }

        public void Draw()
        {
            foreach (var bullet in bullets)
            {
                bullet.Draw();
            }
        }

        public void CreateBullet(Ship ship)
        {
            factoryBullets.CreateBullets(bullets, ship);
        }
    }
}
