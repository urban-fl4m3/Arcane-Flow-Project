using Modules.Behaviours.TickBehaviours;
using UnityEngine;

namespace Modules.Actors.Types
{
    public class ActorBattle : ActorBase, IActorBattle, ICaster
    {
        [SerializeField] public Transform _spawnPoint;

        public int Id => 0;
        public Transform SpawnPoint => _spawnPoint;
        
        protected override void OnAwake()
        {
            
        }
    }
}