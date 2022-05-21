using System;
using Assets.Scripts.Model;

namespace Assets.Scripts.ViewModel
{
    interface IMovementViewModel
    {
        IMovementModel MovementModel { get; }

        event Action GetKeyUp;
        event Action GetKeyDown;
        event Action GetKeyLeft;
        event Action GetKeyRight;

        void Move();
        void MoveFaster();
    }
}
