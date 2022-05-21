using System;
using System.Collections.Generic;
using System.Drawing;

namespace AsteroidsGame_HomeWork_
{
    public sealed class FactoryComet : IFactoryComet
    {
        private Random random = new Random();

        public List<Comet> CreateComet()
        {
            List<Comet>comets = new List<Comet>();
            IMovement movement = new MovementForComet();

            int positionX = random.Next(600, 700);

            comets.Add(new Comet(new Point(positionX, 0), new Point(6, 5), new Size(40, 40), movement));

            return comets;
        }
    }
}
