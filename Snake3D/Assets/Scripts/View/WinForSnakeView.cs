using Assets.Scripts.ViewModel;
using UnityEngine;

namespace Assets.Scripts.View
{
    internal sealed class WinForSnakeView : MonoBehaviour
    {
        public IEndViewModel EndViewModel;

        public void Initialize(IEndViewModel endViewModel)
        {
            EndViewModel = endViewModel;
            EndViewModel.OnWin += WinGame;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent<FoodView>(out FoodView foodView))
            {
                EndViewModel.EatFood();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<BoxCollider>(out BoxCollider boxCollider))
            {
                EndViewModel.ActionDeath();
            }
        }

        private void WinGame()
        {
            Debug.Log("ПОБЕДА!!!");
            Time.timeScale = 0;
        }
    }
}
