using Assets.Scripts.Model;
using System;
using UnityEngine;

namespace Assets.Scripts.ViewModel
{
    interface IBodyViewModel
    {
        IBodyModel BodyModel { get; }

        event Action OnEat;

        void StartAction();
        void AddBodyForSnake();
    }
}
