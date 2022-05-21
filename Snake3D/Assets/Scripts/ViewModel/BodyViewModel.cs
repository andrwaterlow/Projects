using Assets.Scripts.Model;
using System;
using UnityEngine;

namespace Assets.Scripts.ViewModel
{
    internal sealed class BodyViewModel : IBodyViewModel
    {
        public IBodyModel BodyModel { get; }

        public event Action OnEat;
        private GameObject _snake { get; set; }

        public BodyViewModel(IBodyModel bodyModel, GameObject snake)
        {
            BodyModel = bodyModel;
            _snake = snake;
        }

        public void StartAction()
        {
            OnEat.Invoke();
        }

        public void AddBodyForSnake()
        {
            CreateNewBody();
            BodyModel.Newbody.transform.SetParent(_snake.transform);
        }

        private void CreateNewBody()
        {
            SetNewPositionForBody();
            BodyModel.Newbody = GameObject.Instantiate(BodyModel.Body, BodyModel.PositionOfNewBody, Quaternion.identity);
        }

        private void SetNewPositionForBody()
        {
            var numberOfChild = _snake.transform.childCount - 1;
            BodyModel.PositionOfNewBody = _snake.transform.GetChild(numberOfChild).transform.GetChild(0).transform.position;
        }
    }
}
