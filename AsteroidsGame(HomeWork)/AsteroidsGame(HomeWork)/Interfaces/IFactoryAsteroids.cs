using System.Collections.Generic;

namespace AsteroidsGame_HomeWork_
{
    public interface IFactoryAsteroids
    {
        List<Asteroid> CreateAsteroids(int level);
    }
}
