using UnityEngine;

namespace Assets.Scripts.Model
{
    interface IMovementModel
    { 
        float Speed { get; set; }
        Vector3 CourseUp { get; set; }
        Vector3 CourseDown { get; set; }
        Vector3 CourseLeft { get; set; }
        Vector3 CourseRight { get; set; }
        Vector3 CourseCurrent { get; set; }      
    }
}
