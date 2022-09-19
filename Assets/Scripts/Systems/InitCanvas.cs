using Leopotam.EcsLite;
using UnityEngine;

namespace Client {
    sealed class InitCanvas : IEcsInitSystem {
        public void Init (IEcsSystems systems)
        {
            var canvas = GameObject.FindGameObjectWithTag("CanvasScreen");

            var world = systems.GetWorld();
            var entity = world.NewEntity();
            
            var transform = canvas.GetComponent<RectTransform>();
            
            ref var widthCanvasComp = ref world.GetPool<WigthCanvas>().Add(entity);
            widthCanvasComp.Wigth = transform.sizeDelta.x / 2;
        }
    }
}