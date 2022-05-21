using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AsteroidsGame_HomeWork_
{
    public sealed class HealthController : IControlAction
    {
        private List<Health> health;

        private Timer timeCreateHealth;
        private Timer timeOfLifeHealth;

        private IFactoryHealth factory;

        public HealthController(IFactoryHealth factory, List<Health> health)
        {
            this.factory = factory;
            this.health = health;

            SettingTimerForCreate();
            SettingTimerOflife();

            timeCreateHealth.Tick += CreateNewhealth;
            timeCreateHealth.Tick += StopCreateTimer;

            timeOfLifeHealth.Tick += TimeOfLifeIsOver;
            timeOfLifeHealth.Tick += StopLifeTimer;

            StartLifeTimer();
        }

        private void SettingTimerForCreate()
        {
            var timeCreate = 10000;
            timeCreateHealth = new Timer { Interval = timeCreate };
        }

        private void SettingTimerOflife()
        {
            var timeOflife = 7500;
            timeOfLifeHealth = new Timer { Interval = timeOflife };
        }

        private void StartLifeTimer()
        {
            timeOfLifeHealth.Start();
        }

        private void TimeOfLifeIsOver(object sender, EventArgs e)
        {
            var maxHealthOnScreen = 1;

            if (health.Count == maxHealthOnScreen)
            {
                health.RemoveAt(0);
                StartCreateTimer();
            }
        }

        private void StopLifeTimer(object sender, EventArgs e)
        {
            timeOfLifeHealth.Stop();
        }

        public void Death(BaseObject baseObject)
        {
            var HP = (Health)baseObject;
            var index = health.IndexOf(HP);
            health.RemoveAt(index);
            timeOfLifeHealth.Stop();
            timeCreateHealth.Start();
        }

        private void StartCreateTimer()
        {
            timeCreateHealth.Start();
        }

        private void CreateNewhealth(object sender, EventArgs e)
        {
            factory.CreateHealth();
        }

        private void StopCreateTimer(object sender, EventArgs e)
        {
            timeCreateHealth.Stop();
            StartLifeTimer();
        }
    }
}
