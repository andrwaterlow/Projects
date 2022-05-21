using System;
using System.Collections.Generic;
using System.Drawing;

namespace AsteroidsGame_HomeWork_
{
    public sealed class FactoryAsteroids : IFactoryAsteroids
    {
        private Random random = new Random();

        public List<Asteroid> CreateAsteroids(int level)
        {
            var startLevelCount = 15;
            List<Asteroid> Asteroids = new List<Asteroid>();

            for (int i = 0; i < startLevelCount + level; i++)
            {
                Random RandomId = new Random(i);

                var size = random.Next(10, 40);
                int positionX = random.Next(10, 650);
                int positionY = random.Next(10, 450);

                Asteroids.Add(new Asteroid(new Point(positionX, positionY), new Point(random.Next(
                    1, 1 + i), random.Next(1, 1 + i + 1)), new Size(size, size), RandomId.Next(
                        1, 5)));
            }

            return Asteroids;
        }
    }
}
