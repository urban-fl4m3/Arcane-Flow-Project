using Modules.SpellSystem;
using UnityEngine;

namespace Modules.Actors.Types
{
    public class ActorBattle : ActorBase, IActorBattle, ICaster
    {
        [SerializeField] public Transform _spawnPoint;

        public string Id => "0";
        public Transform SpawnPoint => _spawnPoint;
        
        protected override void OnAwake()
        {
            
        }
    }
}