using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.UI;

namespace Client {
    sealed class InitTexCointCount : IEcsInitSystem {
        public void Init (IEcsSystems systems)
        {
            var cointCount = GameObject.FindGameObjectWithTag("Count");

            var world = systems.GetWorld();
            var enitity = world.NewEntity();

            ref var setTextCountCointComp = ref world.GetPool<SetTextCointCount>().Add(enitity);
            setTextCountCointComp.Text = cointCount.GetComponent<Text>();
        }
    }
}