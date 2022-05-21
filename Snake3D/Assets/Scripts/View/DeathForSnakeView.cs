using Assets.Scripts.ViewModel;
using UnityEngine;

namespace Assets.Scripts.View
{
    internal sealed class DeathForSnakeView : MonoBehaviour
    {
        IEndViewModel EndViewModel;

        public void Initialize(IEndViewModel endViewModel)
        {
            EndViewModel = endViewModel;
            EndViewModel.OnDeath += LoseGame;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<BodySnakeView>(out BodySnakeView MovementView))
            {
                EndViewModel.ActionDeath();
            }
        }

        private void LoseGame()
        {
            Debug.Log("Увы вы вне игры!");
            Time.timeScale = 0;
        }
    }
}
