using Assets.Scripts.ViewModel;
using UnityEngine;

namespace Assets.Scripts.View
{
    class FoodView : MonoBehaviour
    {
        private IFoodViewModel _foodViewModel;

        public void Initialize(IFoodViewModel foodViewModel)
        {
            _foodViewModel = foodViewModel;
            _foodViewModel.OnBeEated += Death;
            _foodViewModel.OnBeEated += CreateNewFood;
        }

        private void Death()
        {
            Destroy(_foodViewModel.FoodModel.NewFood);
        }

        private void CreateNewFood()
        {
            _foodViewModel.CreateNewFood();
        }
    }
}
