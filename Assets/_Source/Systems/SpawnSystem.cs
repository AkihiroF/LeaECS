using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    sealed class SpawnSystem : IEcsInitSystem
    {
        public void Init (IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            var filter = world.Filter<BallComponent>().End();
            var pool = world.GetPool<BallComponent>();
            foreach (var entity in filter)
            {
                ref var info = ref pool.Get(entity);
                ref var prefab = ref info.prefab;
                for (int i = 0; i < info.count; i++)
                {
                    Object.Instantiate(prefab, prefab.transform.forward * i, Quaternion.identity);
                }
            }
        }
    }
}