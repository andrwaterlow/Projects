using Assets.Scripts.ViewModel;
using UnityEngine;

namespace Assets.Scripts.View
{
    class EatedFoodView : MonoBehaviour
    {
        private IFoodViewModel _foodViewModel;
        private IMovementViewModel _movementViewModel;

        public void Initialize(IFoodViewModel foodViewModel, IMovementViewModel movementViewModel)
        {
            _foodViewModel = foodViewModel;
            _movementViewModel = movementViewModel;
            _foodViewModel.OnBeEated += MoveFaster;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out FoodView foodView))
            {
                _foodViewModel.ActionEated();    
            }
        }

        private void MoveFaster()
        {
            _movementViewModel.MoveFaster();
        }

        private void Start()
        {
            _foodViewModel.CreateNewFood();
        }
    }
}
