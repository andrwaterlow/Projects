using UnityEngine;

namespace Assets.Scripts.Model
{
    internal sealed class MovementModel : IMovementModel
    {
        public float Speed { get; set; }
        public Vector3 CourseUp { get; set; }
        public Vector3 CourseDown { get; set; }
        public Vector3 CourseLeft { get; set; }
        public Vector3 CourseRight { get; set; }
        public Vector3 CourseCurrent { get; set; }


        public MovementModel(float speed)
        {
            Speed = speed;
            CourseUp = new Vector3();
            CourseDown = new Vector3();
            CourseLeft = new Vector3();
            CourseRight = new Vector3();
            CourseCurrent = new Vector3();
            CreateVector2Course();

        }

        private void CreateVector2Course()
        {
            CourseUp = Vector3.forward;
            CourseDown = Vector3.back; 
            CourseLeft = Vector3.left;
            CourseRight = Vector3.right;
            CourseCurrent = Vector3.zero;
        }
    }
}

