namespace Assets.Scripts.Model
{
    internal sealed class EndModel : IEndModel
    {
        public int MaxFood { get; set; }
        public int CurrentFood { get; set; }

        public EndModel(int maxFood)
        {
            MaxFood = maxFood;
        }
    }
}
