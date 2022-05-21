using System;
using System.Collections.Generic;
using System.Drawing;

namespace AsteroidsGame_HomeWork_
{
    public sealed class FactoryStars : IFactoryStars
    {
        private Random random = new Random();

        public List<BaseObject> CreateStars()
        {
            var count = 20;
            List<BaseObject> Stars = new List<BaseObject>();

            for (int i = 0; i < count; i++)
            {
                Random RandomId = new Random(i);
                int positionX = random.Next(10, 800);
                int positionY = random.Next(10, 600);
                Stars.Add(new Star(new Point(positionX, positionY), new Point(
                    count - i + 1, count - i + 1), new Size(
                        6, 6), RandomId.Next(1, 4)));
            }

            return Stars;
        }
    }
}
