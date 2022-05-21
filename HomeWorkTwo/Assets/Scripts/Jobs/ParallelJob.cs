using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Assets.Scripts.Jobs
{
    public struct ParallelJob : IJobParallelFor
    {
        private NativeArray<Vector3> positions;
        private NativeArray<Vector3> velocities;
        public NativeArray<Vector3> finalPositions;

        public ParallelJob (NativeArray<Vector3> positions, NativeArray<Vector3> velocities)
        {
            this.positions = positions;
            this.velocities = velocities;
            finalPositions = new NativeArray<Vector3>();
        }

        public void Execute(int index)
        {
            finalPositions[index] = positions[index] + velocities[index];
        }
    }
}
