using Assets.Scripts.Jobs;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Assets.Scripts
{
    public sealed class TaskTwo : MonoBehaviour
    {
        [SerializeField] private int countOfVectors;

        private NativeArray<Vector3> positions;
        private NativeArray<Vector3> velocities;

        private NativeArray<Vector3> finalPositions;

        private JobHandle jobHandle;

        void Start()
        {
            positions = new NativeArray<Vector3>(countOfVectors, Allocator.TempJob);
            velocities = new NativeArray<Vector3>(countOfVectors, Allocator.TempJob);
            finalPositions = new NativeArray<Vector3>(countOfVectors, Allocator.TempJob);

            CreateData(positions, velocities);
            PrintData(finalPositions);
            PrintVoid();
            PrintData(positions);
            PrintVoid();
            PrintData(velocities);
            PrintVoid();

            ParallelJob parallelJob = new ParallelJob(positions, velocities);
            parallelJob.finalPositions = finalPositions;
            
            jobHandle = parallelJob.Schedule(countOfVectors, 0);
            jobHandle.Complete();
            PrintData(finalPositions);

            positions.Dispose();
            velocities.Dispose();
            finalPositions.Dispose();
        }

        private void CreateData(NativeArray<Vector3> vectorsOfPositions, NativeArray<Vector3> vectorsOfVelocities)
        {
            for (int i = 0; i < vectorsOfPositions.Length; i++)
            {
                vectorsOfPositions[i] = new Vector3(Random.value, Random.value, Random.value);
                vectorsOfVelocities[i] = new Vector3(Random.value, Random.value, Random.value);
            }
        }

        private void PrintData(NativeArray<Vector3> vectors)
        {
            for (int i = 0; i < vectors.Length; i++)
            {
                Debug.Log(vectors[i]);
            }
        }

        private void PrintVoid()
        {
            Debug.Log("-----------------");
        }
    }
}
