using System;
using System.Drawing;
using System.Windows.Forms;
using AsteroidsGame_HomeWork_.Properties;

namespace AsteroidsGame_HomeWork_.Scenes
{
    public class Game : BaseScene
    {
        private Creater creater;

        private Ship ship;
        private CometsList comet;
        private AsteroidsList asteroids;
        private StarsList stars;
        private BulletsList bullets;
        private HealthList health;

        private Timer timer;

        public override void Init(Form form)
        {
            base.Init(form);

            CheckSizeScreen();
            SetTimerForUpdateAndDraw();
            CreateCreater(form);
            Load();
        }

        private void SetTimerForUpdateAndDraw()
        {
            timer = new Timer { Interval = 60 };
            timer.Tick += OnTick;
            timer.Start();
        }

        private void CreateCreater(Form form)
        {
            creater = new Creater(form, timer);
        }

        private void Load() 
        {
            ship = creater.ship;
            asteroids = creater.asteroidsList;
            stars = creater.starsList;
            comet = creater.comet;
            health = creater.healthList;
            bullets = creater.bulletsList;
        }

        private void OnTick(object sender, EventArgs e) 
        {
            Draw();
            Update();  
        }

        public new void Draw()
        {
            DrawScreen();
            DrawPoints();
            DrawHP();

            asteroids.Draw();
            stars.Draw();
            comet.Draw();
            ship.Draw();
            bullets.Draw();
            health.Draw();

            Buffer.Render();
        }

        public void Update() 
        {
            asteroids.Update();
            stars.Update();
            comet.Update();
            ship.Update();
            health.Update();
            bullets.Update();
        }

        private void DrawScreen()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(Resources.background, new Rectangle(0, 0, 800, 600));
            Buffer.Graphics.DrawImage(Resources.planet, new Rectangle(100, 100, 200, 200));
        }

        private void DrawPoints()
        {
            Buffer.Graphics.DrawString($"Points: {ship.pointsController.Point}", 
                new Font(FontFamily.GenericMonospace, 15, FontStyle.Bold), Brushes.Green, 620, 530);
        }

        private void DrawHP()
        {
            Buffer.Graphics.DrawString($"HP: {ship.HP}", new Font(
                FontFamily.GenericMonospace, 15, FontStyle.Bold), Brushes.Red, 20, 530);
        }

        private void CheckSizeScreen() 
        {
            if (Width > 1000 || Height > 1000  || Width < 0 || Height < 0)
            {
                throw new  ArgumentOutOfRangeException();
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            timer.Stop();
        }    
    }
}
