using AsteroidsGame_HomeWork_.Interfaces;

namespace AsteroidsGame_HomeWork_
{
    public sealed class SoundController : ISound
    {
        private System.Media.SoundPlayer player =
            new System.Media.SoundPlayer();

        public int explode { get; private set; } = 0;
        public int shot { get; private set; } = 1;
        public int medShot { get; private set; } = 2;

        public void PlaySound(int numberOfSound)
        {
            switch (numberOfSound)
            {
                case 0 : Explode();
                    break;
                case 1 : Shot();
                    break;
                case 2 : MedShot();
                    break;
            }
        }

        private  void Explode()
        {
            player.Stream = Properties.Resources.Bomb;
            player.Play();
        }
        private  void Shot()
        {
            player.Stream = Properties.Resources.shot;
            player.Play();
        }
        private  void MedShot()
        {
            player.Stream = Properties.Resources.medshot;
            player.Play();
        }       
    }
}
