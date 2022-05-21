using Assets.Scripts.Model;
using System;

namespace Assets.Scripts.ViewModel
{
    interface IEndViewModel
    {
        IEndModel EndModel { get; set; }

        event Action OnDeath;
        event Action OnWin;

        void ActionDeath();
        void ActionWin();
        void EatFood();
    }
}
