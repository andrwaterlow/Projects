using Assets.Scripts.Jobs;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Assets.Scripts
{
    public sealed class TaskOne : MonoBehaviour
    {
        [SerializeField] private int countOfNumbers;

        private NativeArray<int> numbers;
        private JobHandle jobHandle;

        void Start()
        {
            numbers = new NativeArray<int>(countOfNumbers, Allocator.TempJob);
            CreateData(numbers);
            PrintData(numbers);
            PrintVoid();

            SimpleJob simpleJob = new SimpleJob(numbers);

            jobHandle = simpleJob.Schedule();
            jobHandle.Complete();
            PrintData(numbers);

            numbers.Dispose();
        }

        private void CreateData(NativeArray<int> numbers)
        {
            int minValue = 1;
            int maxValue = 25;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Random.Range(minValue, maxValue);
            }
        }

        private void PrintData(NativeArray<int> numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Debug.Log(numbers[i]);
            }
        }

        private void PrintVoid()
        {
            Debug.Log("-----------------");
        }
    }
}