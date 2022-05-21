namespace AsteroidsGame_HomeWork_
{
    public interface ITakeDamage
    {
         int HP { get; set; }
         void TakeDamage(int damage);
    }
}