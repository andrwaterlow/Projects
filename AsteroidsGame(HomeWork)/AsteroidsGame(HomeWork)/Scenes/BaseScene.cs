using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidsGame_HomeWork_.Scenes
{
    public abstract class BaseScene : IDisposable, IScene
    {
        protected BufferedGraphicsContext context;
        protected Form form;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public virtual void Init(Form form)
        {
            this.form = form;
            Graphics g;
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            form.KeyDown += SceneKeyDown;
        }

        public virtual void SceneKeyDown(object sender, KeyEventArgs e) { }

        public virtual void Draw() { }

        public virtual void Dispose()
        {
            Buffer = null;
            context = null;
            form.KeyDown -= SceneKeyDown;
        }
    }
}
