using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Modules.Actors;
using Modules.Common;
using Modules.Data;
using Modules.SpellSystem.Base;
using Modules.SpellSystem.Providers;
using UnityEngine;

namespace Modules.SpellSystem.Data
{
    [CreateAssetMenu(fileName = "Spell Data", menuName = "Data/Spells")]
    public class SpellData : BaseData
    {
        public Transform SpawnPoint { get; private set; }
        public DynamicInt ActiveSpellId { get; private set; }
        public ISpell ActiveSpell { get; set; }
        
        private IReadOnlyList<string> _spellIds;

        protected override void OnInitialize(IActor owner)
        {
            ActiveSpellId = new DynamicInt();
        }

        public void AddCasterContext(IReadOnlyList<string> spellIds, Transform spawnPoint, int activeSpellId)
        {
            _spellIds = spellIds;
            
            SpawnPoint = spawnPoint;
            ActiveSpellId.Value = activeSpellId;
        }


        public ISpell CreateSpell(int index)
        {   
            var spellId = _spellIds[index];
            var spell = SpellProvider.CreateSpell(Owner, spellId);

            return spell;
        }
    }
}