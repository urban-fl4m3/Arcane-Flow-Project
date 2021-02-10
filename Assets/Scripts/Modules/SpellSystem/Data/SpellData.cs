using System.Collections.Generic;
using Modules.Actors;
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
        public int ActiveSpellId { get; private set; }
        
        private readonly Dictionary<string, ISpell> _spells = new Dictionary<string, ISpell>();
        private IReadOnlyList<string> _spellIds;
        
        protected override void OnInitialize(IActor owner)
        {
        }

        public void AddCasterContext(IReadOnlyList<string> spellIds, Transform spawnPoint, int activeSpellId)
        {
            _spellIds = spellIds;
            
            foreach (var spellID in spellIds)
            {
                _spells.Add(spellID, SpellProvider.CreateSpell(Owner, spellID));
            }

            SpawnPoint = spawnPoint;
            ActiveSpellId = activeSpellId;
        }

        public ISpell GetSpell(int index)
        {
            var spellId = _spellIds[index];
            return _spells[spellId];
        }

        public IReadOnlyDictionary<string, ISpell> Spells => _spells;
    }
}