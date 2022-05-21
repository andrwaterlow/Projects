using System.Drawing;

namespace AsteroidsGame_HomeWork_
{
    public sealed class FactoryShip : IFactoryShip
    {
        public BaseObject CreateShip()
        {
            var ship = new Ship(new Point(400, 500), new Point(10, 0), new Size(35, 40));
            return ship;
        }
    }
}
