using Leopotam.EcsLite;
using UnityEngine;

namespace Client
{
    public class PlayerMonoB : MonoBehaviour
    {
        public EcsWorld World;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Coint"))
            {
                ref var getCointEvent = ref World.GetPool<GetCointEvent>().Add(World.NewEntity());
                getCointEvent.BonusValue = 1;
                Destroy(other.gameObject);
            }
            else
            {
                ref var pauseGameEvent = ref World.GetPool<PauseGameEvent>().Add(World.NewEntity());
                pauseGameEvent.Pause = true;
            }
        }
    }
}