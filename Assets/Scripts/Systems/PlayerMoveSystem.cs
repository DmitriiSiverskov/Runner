using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client {
    sealed class PlayerMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<Move,Player>> _filter = default;

        private readonly EcsPoolInject<Move> _movePool = default;
        private readonly EcsPoolInject<ViewTransform> _viewPool = default;
        
        public void Run (IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref Move moveComp = ref _movePool.Value.Get(entity);
                ref ViewTransform viewComp = ref _viewPool.Value.Get(entity);

                viewComp.Transform.position += new Vector3(0, 0, moveComp.Speed) * Time.deltaTime;
            }
        }
    }
}