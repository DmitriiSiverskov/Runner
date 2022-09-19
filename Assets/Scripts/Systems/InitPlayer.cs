using Leopotam.EcsLite;
using UnityEngine;

namespace Client {
    public sealed class InitPlayer : IEcsInitSystem {
        public void Init (IEcsSystems systems)
        {
            var player = GameObject.FindGameObjectWithTag("Player");

            var world = systems.GetWorld();
            var entity = world.NewEntity();

            ref var moveComp = ref world.GetPool<Move>().Add(entity);
            moveComp.Speed = 5;
            
            world.GetPool<Player>().Add(entity);
            
            ref var viewComp = ref world.GetPool<ViewTransform>().Add(entity);
            viewComp.Transform = player.transform;
            viewComp.Rigidbody = player.GetComponent<Rigidbody>();
            
            ref var animatorControlComp = ref world.GetPool<AnimatorControl>().Add(entity);
            animatorControlComp.AnimatorPlayer = player.GetComponent<Animator>();

            var mb = player.GetComponent<PlayerMonoB>();
            mb.World = world;
        }
    }
}