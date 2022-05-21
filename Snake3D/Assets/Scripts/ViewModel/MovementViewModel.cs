using Assets.Scripts.Model;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ViewModel
{
    internal sealed class MovementViewModel : IMovementViewModel
    {
        public event Action GetKeyUp;
        public event Action GetKeyDown;
        public event Action GetKeyLeft;
        public event Action GetKeyRight;

        private float currentTime;

        private GameObject _snake;

        public IMovementModel MovementModel { get; }
        
        public MovementViewModel(IMovementModel movementModel, GameObject gameObject)
        {
            MovementModel = movementModel;
            _snake = gameObject;
        }

        public void Move()
        {
            currentTime += Time.deltaTime;

            OnAction();

            if (currentTime >= MovementModel.Speed && MovementModel.CourseCurrent != Vector3.zero)
            {
                _snake.transform.GetChild(0).transform.localPosition += MovementModel.CourseCurrent/2;
                MoveBody();
                currentTime = 0;
            }
        }

        public void MoveFaster()
        {
            MovementModel.Speed -= 0.0005f;
        }

        private void MoveBody()
        {
            var childCount = _snake.transform.childCount - 1;
  
            for (int i = childCount; i > 0; i--)
            {
                _snake.transform.GetChild(i).transform.position = _snake.transform.GetChild(
                    i - 1).transform.position;
            }
        }

        private void OnAction()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                GetKeyUp.Invoke();

            if (Input.GetKeyDown(KeyCode.DownArrow))
                GetKeyDown.Invoke(); 

            if (Input.GetKeyDown(KeyCode.LeftArrow))
                GetKeyLeft.Invoke();

            if (Input.GetKeyDown(KeyCode.RightArrow))
                GetKeyRight.Invoke();
        }
    }
}
