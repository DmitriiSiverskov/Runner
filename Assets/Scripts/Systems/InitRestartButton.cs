using Leopotam.EcsLite;
using UnityEngine;

namespace Client {
    sealed class InitRestartButton : IEcsInitSystem {
        public void Init (IEcsSystems systems)
        {
            var restartButton = GameObject.FindGameObjectWithTag("Rstart");

            var world = systems.GetWorld();
            var entity = world.NewEntity();

            ref var flagButtonRestart = ref world.GetPool<SetActiveButtonRestart>().Add(entity);
            flagButtonRestart.Flag = restartButton;
            var mb = restartButton.GetComponent<ClickRestartMonoB>();
            mb.World = world;
            flagButtonRestart.Flag.SetActive(false);
        }
    }
}