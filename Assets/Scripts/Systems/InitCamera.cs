using Leopotam.EcsLite;
using UnityEngine;

namespace Client {
    sealed class InitCamera : IEcsInitSystem {
        public void Init (IEcsSystems systems)
        {
            var camera = GameObject.FindGameObjectWithTag("Camera");

            var world = systems.GetWorld();
            var entity = world.NewEntity();

            ref var moveComp = ref world.GetPool<Move>().Add(entity);
            moveComp.Speed = 5;
           
            ref var viewComp = ref world.GetPool<ViewTransform>().Add(entity);
            viewComp.Transform = camera.transform;
            
        }

        public void Create()
        {
            
        }
    }
}