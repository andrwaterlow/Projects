using Assets.Scripts.Jobs;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

namespace Assets.Scripts
{
    public sealed class TaskThree : MonoBehaviour
    {
        [SerializeField] private GameObject[] bodies;
        [SerializeField] private int SpeedOfrotate;

        private NativeArray<Vector3> velocities;
        private NativeArray<Quaternion> positions;

        private TransformAccessArray transformAccessArray;

        private JobHandle jobHandle;

        void Start()
        {
            velocities = new NativeArray<Vector3>(bodies.Length, Allocator.Persistent);
            positions = new NativeArray<Quaternion>(bodies.Length, Allocator.Persistent);
            CreateData();
        }

        private void Update()
        {
            TransformsJob transformsJob = new TransformsJob()
            {
                Velocities = this.velocities,
                Positions = this.positions,
                DeltaTime = Time.deltaTime
            };

            jobHandle = transformsJob.Schedule(transformAccessArray);
            jobHandle.Complete();
        }

        private void CreateData()
        {

            Transform[] transforms = new Transform[bodies.Length];

            for (int i = 0; i < bodies.Length; i++)
            {
                velocities[i] = new Vector3(Random.value * SpeedOfrotate, Random.value *
                    SpeedOfrotate, Random.value * SpeedOfrotate);
                positions[i] = bodies[i].transform.rotation;
                transforms[i] = bodies[i].transform;
            }

            transformAccessArray = new TransformAccessArray(transforms);
        }

        private void OnDestroy()
        {
            positions.Dispose();
            velocities.Dispose();
            transformAccessArray.Dispose();
        }
    }
}
