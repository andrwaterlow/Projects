using AsteroidsGame_HomeWork_.Scenes;
using System.Windows.Forms;

namespace AsteroidsGame_HomeWork_
{
    public sealed class InputController
    { 
        private Form form;
        private Ship ship;

        public InputController(Form form, Ship ship)
        {
            this.ship = ship;
            this.form = form;
            form.KeyDown += Form_KeyDown;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                ship.Shot();
            }
            if (e.KeyCode == Keys.A)
            {
                ship.Left();
            }
            if (e.KeyCode == Keys.D)
            {
                ship.Right();
            }
            if (e.KeyCode == Keys.Back)
            {
                SceneManager
                    .Get()
                    .Init<MenuScene>(form)
                    .Draw();
            }
        }
    }
}
