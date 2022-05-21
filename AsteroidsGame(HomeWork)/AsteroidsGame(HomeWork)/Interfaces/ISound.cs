namespace AsteroidsGame_HomeWork_.Interfaces
{
    public interface ISound
    {
        int explode { get; } 
        int shot { get; } 
        int medShot { get; } 
        void PlaySound(int numberOfSound);
    }
}
