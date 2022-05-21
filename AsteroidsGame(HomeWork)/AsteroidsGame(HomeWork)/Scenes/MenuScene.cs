using System.Drawing;
using System.Windows.Forms;
using AsteroidsGame_HomeWork_.Properties;

namespace AsteroidsGame_HomeWork_.Scenes
{
    class MenuScene : BaseScene
    {
        public override void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(Resources.main1, new Rectangle(0, 0, 800, 600));
            Buffer.Graphics.DrawString("Меню", new Font(FontFamily.GenericMonospace, 60, FontStyle.Bold), Brushes.DarkBlue, 270, 100);
            Buffer.Graphics.DrawString("Enter - начать игру", new Font(FontFamily.GenericMonospace, 40, FontStyle.Bold), Brushes.Green, 80, 200);
            Buffer.Graphics.DrawString("Esc - выход", new Font(FontFamily.GenericMonospace, 40, FontStyle.Bold), Brushes.Red, 200, 300);
            Buffer.Render();
        }

        public override void SceneKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                form.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                SceneManager
                    .Get()
                    .Init<Game>(form)
                    .Draw();
            }
        }
    }
}
