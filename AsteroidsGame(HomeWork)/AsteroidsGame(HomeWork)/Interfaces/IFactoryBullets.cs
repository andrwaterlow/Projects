using System.Collections.Generic;

namespace AsteroidsGame_HomeWork_
{
    public interface IFactoryBullets
    {
        void CreateBullets(List<BaseObject> objects, Ship ship);
    }
}
