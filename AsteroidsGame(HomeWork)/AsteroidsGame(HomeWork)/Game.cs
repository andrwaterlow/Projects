using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using AsteroidsGame_HomeWork_.Properties;

namespace AsteroidsGame_HomeWork_
{
    static class Game
    {
        private static BufferedGraphicsContext Context;
        public static BufferedGraphics Buffer;
        static Asteroid[] Asteroids;
        static Asteroid[] Stars;
        static Asteroid[] Comets;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static void Init(Form form)
        {
            Graphics g;
            Context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer { Interval = 60 };
            timer.Tick += OnTick;
            timer.Start();
        }
        private static void OnTick(object sender, EventArgs e) //Метод для работы таймера (каждые 60мил.сек. вызываются методы Draw  и Update)
        {
            Draw();
            Update();
        }
        public static void Draw() //метод для вывода на экран графики
        {
            Buffer.Graphics.Clear(Color.Black);

            Buffer.Graphics.DrawImage(Resources.background, new Rectangle(0, 0, 800, 600));

            Buffer.Graphics.DrawImage(Resources.planet, new Rectangle(100, 100, 200, 200));

            foreach (var asteroid in Asteroids)
                asteroid.Draw();

            foreach (var star in Stars)
                star.Draw();

            foreach (var comet in Comets)
                comet.Draw();

            Buffer.Render();
        }
         
        public static void Update() //Метод для загрузки обновленных характеристик обЪектов
        {
            foreach (var asteroid in Asteroids)
                asteroid.Update();

            foreach (var star in Stars)
                star.Update();

            foreach (var comet in Comets)
                comet.Update();
        }

        public static void Load() //метод для инициализации объектов(астероидов, звезд, кометы)
        {
            var random = new Random();
            Asteroids = new Asteroid[15];
            for (int i = 0; i < Asteroids.Length; i++)
            {
                var size = random.Next(10, 40);
                int positionX = random.Next(10, 800);
                int positionY = random.Next(10, 600);
                Asteroids[i] = new Asteroid(new Point(positionX, positionY), new Point(Asteroids.Length + 1 - i , Asteroids.Length + 1 - i ), new Size(size, size));
            }
            Stars = new Asteroid[20];
            for (int i = 0; i < Stars.Length; i++)
            {
                int positionX = random.Next(10, 800);
                int positionY = random.Next(10, 600);
                Stars[i] = new Star(new Point(positionX, positionY), new Point(Stars.Length - i + 1, Stars.Length - i + 1), new Size(6, 6));

            }
            Comets = new Asteroid[1];
            for (int i = 0; i < Comets.Length; i++)
            {
                int positionX = random.Next(600, 700);
                
                Comets[i] = new Comet(new Point(positionX, 0), new Point(6, 5), new Size(40, 40));

            }
        }

    }
}
