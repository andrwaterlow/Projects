using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public sealed class Movement : IMovement
    {
        private IController _controller;
        private ILookAround _lookAround;

        public float _movingSpeed { get; private set; }
        private float GRAVITY = -9.8f;
        private float _heightJump = 500f;
        private bool _jamping;

        private Player _player;
        private CharacterController _characterController;
        

        public Movement(IController controller, float movingSpeed, Player player, CharacterController characterController, ILookAround lookAround)
        {
            _controller = controller;
            _movingSpeed = movingSpeed;
            _player = player;
            _characterController = characterController;
            _lookAround = lookAround;
        }

        public void SetNewSpeed(float speed)
        {
            _movingSpeed = speed;
        }

        public void Move()
        {
            var movement = new Vector3(_controller.MoveAxisX() * _movingSpeed, 0, 
                _controller.MoveAxisZ() * _movingSpeed);
            Jumping();
            movement.y = GRAVITY;
            movement = Vector3.ClampMagnitude(movement, _movingSpeed);
            
            movement *= Time.deltaTime;
            movement = _player.transform.TransformDirection(movement);
            _characterController.Move(movement);
        }

        public void LookAround()
        {
            _lookAround.Rotation();
        }

        public void Jump()
        {
            if (_controller.AxisJump() && _characterController.isGrounded)
            {
                _jamping = true;
            }
        }

        private void Jumping()
        {
            if (_jamping)
            {
                float powerOfJump = 10f;
                float initialValue = 500f;
                float StepOfSubtraction = 15f;

                _heightJump -= StepOfSubtraction;

                if (_heightJump >= 0)
                {
                    GRAVITY = powerOfJump;
                }
                else
                {
                    GRAVITY = -9.8f;
                    _heightJump = initialValue;
                    _jamping = false;
                }
            }
        }
    }
}
