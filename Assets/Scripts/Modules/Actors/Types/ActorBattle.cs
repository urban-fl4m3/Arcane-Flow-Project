using System.Collections.Generic;
using Modules.SpellSystem;
using UnityEngine;

namespace Modules.Actors.Types
{
    public class ActorBattle : ActorBase, IActorBattle, ICaster
    {
        [SerializeField] public Transform _spawnPoint;
        [SerializeField] public List<string> _defaultSpellsByID;
        [SerializeField] public int _activeSkill;
        
        public List<string> ListOfSpellsID => _defaultSpellsByID;
        public Transform SpawnPoint => _spawnPoint;
        public int ActiveSpell => _activeSkill;

        protected override void OnAwake()
        {
            
        }
    }
}