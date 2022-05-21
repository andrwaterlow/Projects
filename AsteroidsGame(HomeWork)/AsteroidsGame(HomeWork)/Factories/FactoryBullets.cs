using System.Collections.Generic;
using System.Drawing;

namespace AsteroidsGame_HomeWork_
{
    public sealed class FactoryBullets : IFactoryBullets
    {
        public void CreateBullets(List<BaseObject> objects, Ship ship)
        {
            if (objects.Count < 4)
                    objects.Add(new Bullet(new Point(ship.CurrentPosition.X, ship.CurrentPosition.Y), new Point(0, 13), new Size(
                        25, 20)));
        }
    }
}
