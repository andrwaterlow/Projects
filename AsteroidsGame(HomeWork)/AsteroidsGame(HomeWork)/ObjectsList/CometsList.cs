using System.Collections.Generic;

namespace AsteroidsGame_HomeWork_
{
    public sealed class CometsList
    {
        private List<Comet> comets;

        public CometsList(IFactoryComet factoryComet)
        {
            comets = factoryComet.CreateComet();
        }

        public void Update()
        {
            for (int i = 0; i < comets.Count; i++)
            {
                comets[i].Update();
            }
        }

        public void Draw()
        {
            foreach (var comet in comets)
            {
                comet.Draw();
            }
        }
    }
}
