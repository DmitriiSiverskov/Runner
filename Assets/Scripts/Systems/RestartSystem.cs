using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Client {
    sealed class RestartSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<SetActiveButtonRestart>> _filter = default;

        private readonly EcsPoolInject<SetActiveButtonRestart> _flagRestartPool = default;

        public void Run(IEcsSystems systems)
        {
            if (Time.timeScale < 1f)
            {
                foreach (var entity in _filter.Value)
                {
                    ref var flagRestartComp = ref _flagRestartPool.Value.Get(entity);
                    flagRestartComp.Flag.SetActive(true);
                }
            }
        }
    }
}