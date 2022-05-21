using System.Windows.Forms;

namespace AsteroidsGame_HomeWork_.Scenes
{
   public interface IScene
    {
        void Init(Form form);
        void Draw();
    }
}
