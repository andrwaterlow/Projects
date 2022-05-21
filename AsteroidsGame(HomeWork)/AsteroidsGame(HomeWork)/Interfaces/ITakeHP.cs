namespace AsteroidsGame_HomeWork_
{
    public interface ITakeHP
    {
        int HP { get; set; }
        void TakeHP(int damage);
    }
}