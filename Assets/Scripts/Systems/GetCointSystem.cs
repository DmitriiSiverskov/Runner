using System;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client {
    sealed class GetCointSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<GetCointEvent>> _filter = default;
        private readonly EcsFilterInject<Inc<SetTextCointCount>> _filter1 = default;
        private readonly EcsFilterInject<Inc<PauseGameEvent>> _filter2 = default;
       
        private readonly EcsPoolInject<PauseGameEvent> _pauseGamePool = default;
        private readonly EcsPoolInject<GetCointEvent> _getCointPool = default;
        private readonly EcsPoolInject<SetTextCointCount> _setTextCointPool = default;
        
        public void Run (IEcsSystems systems)
        {
            foreach (var j in _filter2.Value)
            {
                ref PauseGameEvent pauseGameEvent = ref _pauseGamePool.Value.Get(j);
                if (pauseGameEvent.Pause)
                {
                    Time.timeScale = 0;
                }
            }
            foreach (var entity in _filter.Value)
            {
                ref GetCointEvent getCointEvent = ref _getCointPool.Value.Get(entity);
                
                foreach (var i in _filter1.Value)
                {
                    ref SetTextCointCount setTextCointComp = ref _setTextCointPool.Value.Get(i);
                    var result = Convert.ToInt32(setTextCointComp.Text.text) + getCointEvent.BonusValue;
                    setTextCointComp.Text.text = Convert.ToString(result);
                }
            }
        }
    }
}