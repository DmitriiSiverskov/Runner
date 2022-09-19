using Leopotam.EcsLite;
using UnityEngine;

namespace Client {
    sealed class InitCoint : IEcsInitSystem {
        public void Init (IEcsSystems systems)
        {
            var coint = GameObject.FindGameObjectWithTag("Coint");
            
            var world = systems.GetWorld();
            var entity = world.NewEntity();

            ref var animatorControlComp = ref world.GetPool<AnimatorControl>().Add(entity);
            animatorControlComp.AnimatorPlayer = coint.GetComponent<Animator>();

            ref var viewTransformCointComp = ref world.GetPool<ViewTransform>().Add(entity);
            viewTransformCointComp.Transform = coint.transform;

            Vector3 transformPosition = viewTransformCointComp.Transform.position;
            
            while (transformPosition.z < 150.0f)
            {
                transformPosition.x = Random.Range(-4, 4);
                transformPosition.z += 5.0f;
                GameObject.Instantiate(coint,transformPosition,Quaternion.identity);
            }
        }
    }
}