using Unity.Collections;
using Unity.Jobs;

namespace Assets.Scripts.Jobs
{
    public struct SimpleJob : IJob
    {
        public NativeArray<int> Numbers;

        public SimpleJob(NativeArray<int> numbers)
        {
            Numbers = numbers;
        }

        public void Execute()
        {
            for (int i = 0; i < Numbers.Length; i++)
            {
                if (Numbers[i] < 10)
                {
                    Numbers[i] = 0;
                }
            }
        }
    }
}
