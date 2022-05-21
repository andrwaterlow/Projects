using Assets.Scripts.Model;
using System;

namespace Assets.Scripts.ViewModel
{
    class EndViewModel : IEndViewModel
    {
        public IEndModel EndModel { get; set; }

        public event Action OnDeath;
        public event Action OnWin;

        public EndViewModel(IEndModel endModel)
        {
            EndModel = endModel;
        }

        public void ActionDeath()
        {
            OnDeath.Invoke();
        }

        public void ActionWin()
        {
            OnWin.Invoke();
        }

        public void EatFood()
        {
            EndModel.CurrentFood++;

            if (EndModel.CurrentFood >= EndModel.MaxFood)
            {
                OnWin.Invoke();
            }
        }
    }
}
