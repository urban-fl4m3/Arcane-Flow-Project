using System.Collections.Generic;
using Modules.SpellSystem.Data;
using UnityEngine;

namespace Modules.Actors.Types
{
    public class ActorBattle : ActorBase, IActorBattle
    {
        [SerializeField] public Transform _spawnPoint;
        [SerializeField] public List<string> _defaultSpellsByID;
        [SerializeField] public int _activeSkill;

        protected override void OnAwake()
        {
            var spellData = GetData<SpellData>();
            spellData.AddCasterContext(_defaultSpellsByID, _spawnPoint, _activeSkill);
        }
    }
}