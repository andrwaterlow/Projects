using Assets.Scripts.Model;
using System;

namespace Assets.Scripts.ViewModel
{
    interface IFoodViewModel
    {
        IFoodModel FoodModel { get; set; }

        event Action OnBeEated;

        public void CreateNewFood();
        public void ActionEated();
    }
}
