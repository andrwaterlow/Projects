using Assets.Scripts.ViewModel;
using UnityEngine;

namespace Assets.Scripts.View
{
    internal sealed class BodySnakeView : MonoBehaviour
    {
        private IBodyViewModel _bodyViewModel;

        public void Initialize(IBodyViewModel bodyViewModel)
        {
            _bodyViewModel = bodyViewModel;
            _bodyViewModel.OnEat += EatFood;
        }

        private void EatFood()
        {
            _bodyViewModel.AddBodyForSnake();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.TryGetComponent<FoodView>(out FoodView FoodView))
            {
                _bodyViewModel.StartAction();
            }
        } 
    }
}
