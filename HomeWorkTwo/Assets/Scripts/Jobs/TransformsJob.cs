using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;

namespace Assets.Scripts.Jobs
{
    public struct TransformsJob : IJobParallelForTransform
    {
        public NativeArray<Vector3> Velocities;
        public NativeArray<Quaternion> Positions;

        public float DeltaTime;

        public void Execute(int index, TransformAccess transform)
        {
            Vector3 rotate = Velocities[index] * DeltaTime;

            transform.rotation *= Quaternion.Euler(rotate);
            Positions[index] = transform.rotation;
        }
    }
}
