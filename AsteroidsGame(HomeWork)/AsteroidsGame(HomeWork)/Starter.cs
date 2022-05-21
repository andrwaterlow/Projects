using AsteroidsGame_HomeWork_.Scenes;
using System.Windows.Forms;

namespace AsteroidsGame_HomeWork_
{
    public sealed class Starter
    {
        public static void StartGame()
        {
            var form = new Form()
            {
                MinimumSize = new System.Drawing.Size(800, 600),
                MaximumSize = new System.Drawing.Size(800, 600),
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.CenterScreen,
                Text = "Asteroids"
            };
            form.Show();

            SceneManager
                .Get()
                .Init<MenuScene>(form)
                .Draw();

            Application.Run(form);
        }
    }   
}
