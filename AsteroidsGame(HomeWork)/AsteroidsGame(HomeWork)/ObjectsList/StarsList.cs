using System.Collections.Generic;

namespace AsteroidsGame_HomeWork_
{
    public sealed class StarsList
    {
        private List<BaseObject> stars;

        public StarsList(IFactoryStars factoryStars)
        {
            stars = factoryStars.CreateStars();
        }

        public void Update()
        {
            foreach (var star in stars)
            {
                star.Update();
            }
        }

        public void Draw()
        {
            foreach (var star in stars)
            {
                star.Draw();  
            }
        }
    }
}
