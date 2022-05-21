using AsteroidsGame_HomeWork_.Interfaces;
using System.Collections.Generic;

namespace AsteroidsGame_HomeWork_
{
    public sealed class HealthList
    {
        private IControlAction controlAction;
        private IControlCollision controlCollision;
        private ITakeHP shipTakeHP;
        private ISound sound;

        private List<Health>health;

        public HealthList(IFactoryHealth factoryHealth, ICollision ship, ITakeHP shipTakeHP)
        {
            health = factoryHealth.CreateHealth();
            this.controlAction = new HealthController(factoryHealth, health);
            this.controlCollision = new HealthControllerCollision(ship);
            this.shipTakeHP = shipTakeHP;
        }

        public void LoadDataObject(ISound sound)
        {
            this.sound = sound;
        }

        public void Update()
        {
            for (int i = 0; i < health.Count; i++)
            {
                CheckCollisionWithShip(health[i]);
            }
        }

        private void CheckCollisionWithShip(Health health)
        {
            if (controlCollision.CollisionObjectWithObject(health))
            {
                sound.PlaySound(sound.medShot);
                shipTakeHP.TakeHP(health.HP);
                controlAction.Death(health);
            }
        }

        public void Draw()
        {
            foreach (var health in health)
            {
                health.Draw();
            }          
        }
    }
}
