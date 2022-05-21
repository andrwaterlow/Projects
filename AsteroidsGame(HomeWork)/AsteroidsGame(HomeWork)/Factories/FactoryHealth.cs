using System;
using System.Collections.Generic;
using System.Drawing;

namespace AsteroidsGame_HomeWork_
{
    public sealed class FactoryHealth : IFactoryHealth
    {
        private Random random = new Random();
        private List<Health> healths;

        public FactoryHealth()
        {
            healths = new List<Health>();
        }

        public List<Health> CreateHealth()
        {
            var health = new Health(new Point(random.Next(100, 700), 500), new Point(0, 0), new Size(25, 25), 25);
            healths.Add(health);
            return healths;
        }
    }
}
