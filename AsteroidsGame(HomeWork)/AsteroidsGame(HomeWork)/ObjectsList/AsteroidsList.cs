using AsteroidsGame_HomeWork_.Interfaces;
using System;
using System.Collections.Generic;

namespace AsteroidsGame_HomeWork_
{
    public sealed class AsteroidsList
    {
        public List<Asteroid> asteroids = new List<Asteroid>();

        internal IFactoryAsteroids factoryAsteroids;
        private IControlAction controlAction;
        private IControlCollision controlCollision;
        private ITakeDamage shipDamage;
        private ISound sound;

        public event Action LevelUp;
        public event Action PointUp;

        public AsteroidsList(IFactoryAsteroids factoryAsteroids, ICollision ship, ITakeDamage shipDamage)
        {
            this.factoryAsteroids = factoryAsteroids;
            this.shipDamage = shipDamage;
            asteroids = factoryAsteroids.CreateAsteroids(0);
            controlAction = new AsteroidsController(asteroids);
            controlCollision = new AsteroidsControllerColision(ship);
        }

        public void LoadDataObject(ISound sound)
        {
            this.sound = sound;
        }

        public void Update()
        {
            CheckCollisionWithBullets();
            CheckCollisionWithShipAndUpdate();
            CheckCountOfAsteroids();
        }

        private void CheckCollisionWithBullets()
        {
            for (int i = 0; i < asteroids.Count; i++)
            {
                if (asteroids[i].Collision)
                {
                    controlAction.Death(asteroids[i]);
                    PointUp.Invoke();
                    sound.PlaySound(sound.explode);
                }
            }
        }

        private void CheckCollisionWithShipAndUpdate()
        {
            for (int i = 0; i < asteroids.Count; i++)
            {
                asteroids[i].Update();
                if (controlCollision.CollisionObjectWithObject(asteroids[i]))
                {
                    shipDamage.TakeDamage(asteroids[i].RandomDamage());
                    sound.PlaySound(sound.explode);
                    asteroids.RemoveAt(i);
                }
            }
        }

        private void CheckCountOfAsteroids()
        {
            var minCountOfAsteroids = 1;
            if (asteroids.Count < minCountOfAsteroids)
            {
                LevelUp.Invoke();
                CreateNewController();
            }

        }

        private void CreateNewController()
        {
            controlAction = new AsteroidsController(asteroids);
        }

        public void Draw()
        {
            foreach (var asteriod in asteroids)
            {
                asteriod.Draw();
            }
        }
    }
}
