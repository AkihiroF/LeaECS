using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems {
    sealed class MovementSystem : IEcsInitSystem , IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<MovementParameters> _pool;
        public void Init (IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<MovementParameters>().End();
            _pool = world.GetPool<MovementParameters>();
        }

        public void Run(IEcsSystems systems)
        {
            float deltaTime = Time.deltaTime;
            foreach (int entity in _filter)
            {
                ref var info = ref _pool.Get(entity);
                ref var transform = ref info.body;
                ref var speed = ref info.forwardSpeed;
                ref var amplitude = ref info.zigzagAmplitude;
                ref var frequency = ref info.zigzagFrequency;

                Vector3 forward = transform.forward * speed * deltaTime;
                transform.position += forward;

                float zigzagOffset = amplitude * Mathf.Sin(frequency * deltaTime);
                Vector3 right = transform.right;
                Vector3 zigzagMovement = right * zigzagOffset;
                transform.position += zigzagMovement;
            }
        }
    }
}