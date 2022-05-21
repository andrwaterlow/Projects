using AsteroidsGame_HomeWork_.Scenes;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidsGame_HomeWork_
{
    public sealed class GameController
    {
        private int level = 0;
        private AsteroidsList asteroidsList;
        private Ship ship;
        private Timer timer;
        private PointsController pointsController;

        public GameController(AsteroidsList asteroidsList, Ship ship, Timer timer, PointsController pointsController)
        {
            this.asteroidsList = asteroidsList;
            this.ship = ship;
            this.timer = timer;
            this.pointsController = pointsController;
            ship.MessageDie += ShipDie;
            asteroidsList.LevelUp += LevelUp;
            asteroidsList.PointUp += PointUp;
        }

        private void LevelUp()
        {
            level++;
            asteroidsList.asteroids = asteroidsList.factoryAsteroids.CreateAsteroids(level);
        }

        private void PointUp()
        {
            pointsController.PointUp();
        }

        private void ShipDie()
        {
            Game.Buffer.Graphics.DrawString("Game Over", new Font(FontFamily.GenericMonospace, 60, FontStyle.Bold), Brushes.Red, 170, 210);
            Game.Buffer.Graphics.DrawString("Backspace - в меню", new Font(FontFamily.GenericMonospace, 40, FontStyle.Bold), Brushes.Green, 100, 320);
            Game.Buffer.Render();
            timer.Stop();
        }
    }
}
