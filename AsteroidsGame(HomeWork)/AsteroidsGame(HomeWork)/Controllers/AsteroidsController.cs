using System.Collections.Generic;

namespace AsteroidsGame_HomeWork_
{
    public sealed class AsteroidsController : IControlAction
    {
        private List<Asteroid> asteroids;

        public AsteroidsController(List<Asteroid> asteroids)
        {
            this.asteroids = asteroids;
        }

        public void Death(BaseObject baseObject)
        {
            var asteroid = (Asteroid)baseObject;
            var index = asteroids.IndexOf(asteroid);
            asteroids.RemoveAt(index);
        }   
    }
}
