using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client {
    sealed class TochSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<WigthCanvas>> _filter = default;
        private readonly EcsFilterInject<Inc<Move>> _filter1 = default;

        private readonly EcsPoolInject<Move> _movePool = default;
        private readonly EcsPoolInject<ViewTransform> _viewPool = default;
        private readonly EcsPoolInject<WigthCanvas> _widthCanvasPool = default;
        
        public void Run (IEcsSystems systems)
        {
            if (Input.GetMouseButton(0))
            {
                var pointClick = Input.mousePosition.x;
                foreach (var entity in _filter.Value)
                {
                    ref WigthCanvas wigthCanvasComp = ref _widthCanvasPool.Value.Get(entity);
                    
                    foreach (var i in _filter1.Value)
                    {
                        ref Move moveComp = ref _movePool.Value.Get(i);
                        ref ViewTransform viewComp = ref _viewPool.Value.Get(i);
                        
                        if (pointClick > wigthCanvasComp.Wigth)
                        {
                            if (viewComp.Transform.position.x > 4)
                            {
                                return;
                            }
                            viewComp.Transform.position += new Vector3(moveComp.Speed, 0, 0) * Time.deltaTime;
                        }
                        else if(pointClick < wigthCanvasComp.Wigth)
                        {
                            if (viewComp.Transform.position.x < -4)
                            {
                                return;
                            }
                            viewComp.Transform.position -= new Vector3(moveComp.Speed,0,0) * Time.deltaTime;
                        }
                    }
                }
            }
        }
    }
}